import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.select.Elements;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;
import java.util.concurrent.ConcurrentHashMap;

public class Main {

    public static void main(String[] args) {

        Map<String, Integer> pages = new ConcurrentHashMap<String, Integer>();

        String siteUrl = "http://astappev.info/harkovchane/index.htm";
        String outputDir = "E:\\Desktop\\output\\";
        int level = 2;

        pages.put(siteUrl, 0);

        String domain = getHost(siteUrl);

        Document doc;
        for(int lev = 0; lev < level; lev++)
        {

            Iterator<String> iterator = pages.keySet().iterator();
            while(iterator.hasNext()){
                String url = iterator.next();
                Integer url_level = pages.get(url);
                System.out.printf("Check %s on level %d%n", url, url_level);

                try {
                    doc = Jsoup.connect(url).get();

                    Elements links = doc.select("a");
                    for(int i = 0, size = links.size(); i < size; ++i)
                    {
                        String href = links.get(i).attr("href").toString();
                        if(!href.startsWith("http://") && !href.startsWith("https://"))
                        {
                            if(href.startsWith("#")) continue;
                            String baseUri = links.get(i).baseUri();
                            href = baseUri.substring(0, baseUri.lastIndexOf('/') + 1) + href;
                        }

                        if(!domain.equals(getHost(href))) continue;

                        if(pages.get(href) == null)
                        {
                            pages.put(href, lev + 1);
                            System.out.printf("Added %s on level %d%n", href, lev + 1);
                        }
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        Iterator<String> iterator = pages.keySet().iterator();
        int i = 0;
        while(iterator.hasNext()) {
            String url = iterator.next();
            Integer url_level = pages.get(url);

            try {
                doc = Jsoup.connect(url).get();

                Elements meta = doc.select("html head meta");
                if (!domain.equals(getHost(doc.location()))) continue;

                String text = doc.body().select("#content").text();

                File file = new File(outputDir + "page_" + i++ + ".txt");
                BufferedWriter writer = new BufferedWriter(new FileWriter(file));
                writer.write(text);
                writer.close();

            } catch (IOException e) {
                //e.printStackTrace();
            }
        }
    }

    public static String getHost(String url){
        if(url == null || url.length() == 0)
            return "";

        int doubleslash = url.indexOf("//");
        if(doubleslash == -1)
            doubleslash = 0;
        else
            doubleslash += 2;

        int end = url.indexOf('/', doubleslash);
        end = end >= 0 ? end : url.length();

        int port = url.indexOf(':', doubleslash);
        end = (port > 0 && port < end) ? port : end;

        return url.substring(doubleslash, end);
    }
}

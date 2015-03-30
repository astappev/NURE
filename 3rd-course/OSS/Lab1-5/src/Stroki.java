/**
 * Created with IntelliJ IDEA.
 * User: Oleg
 * Date: 11.10.14
 * Time: 8:32
 * To change this template use File | Settings | File Templates.
 */
public class Stroki {
    public static void main(String args[]) throws java.io.IOException {
        System.out.println("Введите строку:");
        byte[] b1 = new byte[200];
        int n1 = System.in.read(b1);

        String str = new String(b1, 0, n1);

        String replace_from = "країна";
        String replace_to = "Україна";
        str = str.replaceAll(replace_from, replace_to);

        System.out.println(str);
    }
}

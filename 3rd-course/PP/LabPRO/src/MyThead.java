public class MyThead extends Thread {

    public void run() {
        System.out.println("Hello world!");
    }

    public static void main(String[] args) {
        MyThead t = new MyThead();
        t.start();
    }
}

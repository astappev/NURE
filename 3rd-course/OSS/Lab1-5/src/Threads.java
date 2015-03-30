/* 1. У першому потоці треба виконувати обчислення інтегралу від деякої функції, а в іншому – іншого інтегралу.
Після закінчення обчислень результати необхідно вивести на екран.*/

public class Threads {

    public static void main(String[] args) {
        Object sync1 = new Object();
        Object sync2 = new Object();

        TrapIntegral t1 = new TrapIntegral(0.0, 3.0);
        TrapIntegral t2 = new TrapIntegral(1.0, 2.0);
        ReturnThread TReturn = new ReturnThread(t1, t2);

        TReturn.setMonitor(sync1, sync2);
        t1.setMonitor(sync1);
        t2.setMonitor(sync2);
        
        /*ExecutorService exec = Executors.newCachedThreadPool();
        exec.execute(TReturn);
        exec.execute(t1);
        exec.execute(t2);
        exec.shutdown();*/

        TReturn.start();
        t1.start();
        t2.start();
    }

}

class TrapIntegral extends Thread { //implements Runnable
    double a;
    double b;
    double n = 1000;
    double result;
    Object sync;

    public TrapIntegral(double a, double b) {
        this.a = a;
        this.b = b;
    }

    public void setMonitor(Object o) {
        this.sync = o;
    }

    public void run() {
        synchronized (sync) {
            double n = 1000;
            double h = (b - a) / n;
            double sum = 0.0;
            for (double i = a; i < b; i += h) {
                sum += (h / 6)*(f(i) + 4 * f((i + h + i) / 2.0) + f(i + h));
            }
            this.result = sum;

            sync.notifyAll();
        }
    }

    public double getResult() {
        return this.result;
    }

    double f(double x) {
        return (7 * x*x*x*x - x*x*x + 6 * x*x - 9 * x - 12);
    }
}

class ReturnThread extends Thread {
    private Object sync1, sync2;
    TrapIntegral a, b;

    public ReturnThread(TrapIntegral a, TrapIntegral b) {
        this.a = a;
        this.b = b;
    }

    public void setMonitor(Object sync1, Object sync2) {
        this.sync1 = sync1;
        this.sync2 = sync2;
    }

    public void run() {
        synchronized (sync1) {
            synchronized (sync2) {
                try {
                    sync1.wait();
                    sync2.wait();
                } catch (InterruptedException e) {
                    System.out.println("Прерван: " + e.getMessage());
                }
            }
        }
        System.out.println("Потоки закончили выполнение\nЗначение1: " + a.getResult() + "\nЗначение2: " + b.getResult());
    }
}
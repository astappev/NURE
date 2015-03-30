public class Run {
    public static void main(String[] args) throws InterruptedException {
        int count = 5;

        MyPhilosopher[] phils = new MyPhilosopher[count];

        Fork last = new Fork();
        Fork left = last;

        for (int i = 0; i < count; i++) {
            Fork right = (i == count-1) ? last : new Fork();
            phils[i] = new MyPhilosopher(i, left, right);
            left = right;
        }

        Thread[] threads = new Thread[count];
        for (int i = 0; i < count; i++) {
            threads[i] = new Thread(phils[i]);
            threads[i].start();
        }

        Thread.sleep(60000);

        for (MyPhilosopher phil : phils) {
            phil.stopFlag = true;
        }

        for (Thread thread : threads) {
            thread.join();
        }

        for (MyPhilosopher phil : phils) {
            System.out.println("[Philosopher " + phil.position + "] ate " + phil.eatCount + " times and waited " + phil.waitTime + " ms.");
        }
    }
}

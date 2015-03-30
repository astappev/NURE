public class MyPhilosopher extends Philosopher implements Runnable {
	volatile boolean stopFlag = false;

	public MyPhilosopher(int position, Fork left, Fork right, int maxThinkingTime, int maxEatingTime) {
		super(position, left, right, maxThinkingTime, maxEatingTime);
	}

	public void run() {
		while (!stopFlag) {
			think();
			System.out.println("[Philosopher " + position + "] took left fork");
			if (!left.took(this)) continue;
			System.out.println("[Philosopher " + position + "] took right fork");
			if (!right.took(this)) continue;
			eat();

		}
		System.out.println("[Philosopher " + position + "] stopped");
	}
}

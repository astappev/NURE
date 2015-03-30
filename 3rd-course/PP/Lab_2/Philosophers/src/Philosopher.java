import java.util.Random;

enum State {
	Thinking,
	Eating,
	Starving
}

public class Philosopher {
	State state;
	int position;
	final Fork left;
	final Fork right;
	int eatCount = 0;
	long waitTime = 0;
	long startWait;
	Random rnd = new Random();
	int maxEatingTime;
	int maxThinkingTime;

	public Philosopher(int position, Fork left, Fork right, int maxThinkingTime, int maxEatingTime) {
		this.state = State.Thinking;
		this.position = position;
		this.maxThinkingTime = maxThinkingTime;
		this.maxEatingTime = maxEatingTime;
		left.took(this);
		this.left = left;
		this.right = right;
	}

	public void eat() {
		this.state = State.Eating;
		waitTime += System.currentTimeMillis() - startWait;
		System.out.println("[Philosopher " + position + "] is eating");
		try {
			Thread.sleep(rnd.nextInt(maxEatingTime));
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		eatCount++;
		System.out.println("[Philosopher " + position + "] finished eating");
		left.clean = false;
		right.clean = false;
	}

	public void think() {
		this.state = State.Thinking;
		System.out.println("[Philosopher " + position + "] is thinking");
		try {
			Thread.sleep(rnd.nextInt(maxThinkingTime));
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		this.state = State.Starving;
		System.out.println("[Philosopher " + position + "] is hungry");
		startWait = System.currentTimeMillis();
	}
}

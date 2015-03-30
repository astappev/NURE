import java.util.Random;

public class Philosopher {
    int position;
    final Fork left;
    final Fork right;
    int eatCount = 0;
    long waitTime = 0;

    public Philosopher(int position, Fork left, Fork right) {
        this.position = position;
        this.left = left;
        this.right = right;
    }

    public void eat() {
        this.eatCount++;
    }

    public void think() {
        this.waitTime++;
    }
}

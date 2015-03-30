public class Fork {
	boolean clean = false;
	Philosopher owner;

	public synchronized boolean took(Philosopher phil) {
		if (this.owner == phil)
			return true;

		if (this.owner == null || this.owner.state == State.Thinking || !clean) {
			this.clean = true;
			this.owner = phil;
			return true;
		}

		return false;
	}
}

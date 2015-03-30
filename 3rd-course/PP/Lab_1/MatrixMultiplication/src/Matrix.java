import java.util.Random;

public class Matrix {

    private int height;
    private int weight;
    private int[][] data;

    public Matrix() {
        this.height = 100;
        this.weight = 100;
        this.data = new int[height][weight];
        randomized();
    }

    public Matrix(int height, int weight) {
        this.height = height;
        this.weight = weight;
        this.data = new int[height][weight];
        randomized();
    }

    public Matrix(int height, int weight, Boolean free) {
        this.height = height;
        this.weight = weight;
        this.data = new int[height][weight];
    }

    public int getHeight() {
        return this.height;
    }

    public int getWeight() {
        return this.weight;
    }

    public String toString() {
        return "Матрица размером " + this.height + "*" + this.weight;
    }

    public int get(int i, int j) {
        return this.data[i][j];
    }

    public void set(int i, int j, int value) {
        this.data[i][j] = value;
    }

    public void output() {
        for (int i = 0; i < this.height; ++i, System.out.println()) {
            for (int j = 0; j < this.weight; ++j) {
                System.out.print(this.data[i][j] + " ");
            }
        }
    }

    public void randomized() {
        for (int i = 0; i < height; ++i) {
            for (int j = 0; j < weight; ++j) {
                data[i][j] = randInt(0, 1000);
            }
        }
    }

    private int randInt(int min, int max) {
        Random rand = new Random();
        int randomNum = rand.nextInt((max - min) + 1) + min;
        return randomNum;
    }

    public Matrix multiplication(Matrix twoMatrix) {

        if (this.getWeight() != twoMatrix.getHeight()) {
            throw new IllegalArgumentException("Матрица размером " + this.getHeight() + "*" + this.getWeight() +
                    " не может быть умножена на матрицу, размером " + twoMatrix.getHeight() + "*" + twoMatrix.getWeight() + ".");
        }

        Matrix resultMatrix = new Matrix(this.getHeight(), twoMatrix.getWeight(), true);
        for (int i = 0; i < this.getHeight(); i++) {
            for (int j = 0; j < twoMatrix.getWeight(); j++) {
                int sum = 0;
                for (int k = 0; k < twoMatrix.getHeight(); k++) {
                    sum += this.get(i, k) * twoMatrix.get(k, j);
                }
                resultMatrix.set(i, j, sum);
            }
        }

        return resultMatrix;
    }

    public Matrix parallelMultiplication(Matrix twoMatrix) {

        if (this.getWeight() != twoMatrix.getHeight()) {
            throw new IllegalArgumentException("Матрица размером " + this.getHeight() + "*" + this.getWeight() +
                    " не может быть умножена на матрицу, размером " + twoMatrix.getHeight() + "*" + twoMatrix.getWeight() + ".");
        }

        Runtime runtime = Runtime.getRuntime();
        int numberOfThreads = runtime.availableProcessors();
        ParallelMultiply[] threads = new ParallelMultiply[numberOfThreads];

        Matrix resultMatrix = new Matrix(this.getHeight(), twoMatrix.getWeight(), true);
        for (int i = 0; i < numberOfThreads; i++ ) {
            threads[i] = new ParallelMultiply(this, twoMatrix, resultMatrix, i, numberOfThreads);
            threads[i].start();
        }

        try {
            for (int i = 0; i < threads.length; i++ ) {
                threads[i].join();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        return resultMatrix;
    }

    public Matrix parallelMultiplication(Matrix twoMatrix, int processors) {

        if (this.getWeight() != twoMatrix.getHeight()) {
            throw new IllegalArgumentException("Матрица размером " + this.getHeight() + "*" + this.getWeight() +
                    " не может быть умножена на матрицу, размером " + twoMatrix.getHeight() + "*" + twoMatrix.getWeight() + ".");
        }

        int numberOfThreads = processors;
        ParallelMultiply[] threads = new ParallelMultiply[numberOfThreads];

        Matrix resultMatrix = new Matrix(this.getHeight(), twoMatrix.getWeight(), true);
        for (int i = 0; i < numberOfThreads; i++ ) {
            threads[i] = new ParallelMultiply(this, twoMatrix, resultMatrix, i, numberOfThreads);
            threads[i].start();
        }

        try {
            for (int i = 0; i < threads.length; i++ ) {
                threads[i].join();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        return resultMatrix;
    }
}


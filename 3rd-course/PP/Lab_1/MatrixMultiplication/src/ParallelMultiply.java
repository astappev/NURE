public class ParallelMultiply extends Thread {

    private Matrix firstMatrix;
    private Matrix secondMatrix;
    private Matrix result;

    private int currentNum;
    private int numProc;

    public ParallelMultiply(Matrix firstMatrix, Matrix secondMatrix, Matrix result, int currentNum, int numProc) {

        this.firstMatrix = firstMatrix;
        this.secondMatrix = secondMatrix;
        this.result = result;
        this.currentNum = currentNum;
        this.numProc = numProc;
    }

    public void run() {
        int i = 0, j = 0, k = 0;
        try {
            for (i = this.firstMatrix.getHeight() / this.numProc * this.currentNum; i < (this.firstMatrix.getHeight() / this.numProc * (this.currentNum + 1)); i++) {
                for (j = 0; j < this.secondMatrix.getWeight(); j++) {
                    int sum = 0;
                    for (k = 0; k < this.secondMatrix.getHeight(); k++) {
                        sum += this.firstMatrix.get(i, k) * this.secondMatrix.get(k, j);
                    }
                    this.result.set(i, j, sum);
                }
            }
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("Выход за диапазон:" + i + " " + j + " " + k + " " + this.currentNum);
        }

    }
}

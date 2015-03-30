public class Main {

    public static void main(String[] args) {

        long start, end;

        /*start = System.nanoTime();
        Matrix oneMatrix = new Matrix();
        end = System.nanoTime();
        System.out.println(oneMatrix);
        System.out.println("Время инициализации: " + ((double)(end-start)/1000000) + " миллисекунд");*/

        start = System.nanoTime();
        Matrix twoMatrix = new Matrix(100, 4200);
        end = System.nanoTime();
        System.out.println(twoMatrix);
        System.out.println("Время инициализации: " + ((double)(end-start)/1000000) + " миллисекунд");

        start = System.nanoTime();
        Matrix threeMatrix = new Matrix(4200, 203);
        end = System.nanoTime();
        System.out.println(threeMatrix);
        System.out.println("Время инициализации: " + ((double)(end-start)/1000000) + " миллисекунд");

        //twoMatrix.output();
        //threeMatrix.output();
        start = System.nanoTime();
        Matrix sumMatrix = twoMatrix.multiplication(threeMatrix);
        end = System.nanoTime();
        System.out.println("Последовательное умножение: " + ((double)(end-start)/1000000) + " миллисекунд");
        //sumMatrix.output();

        //twoMatrix.output();
        //threeMatrix.output();
        start = System.nanoTime();
        Matrix sumParMatrix = twoMatrix.parallelMultiplication(threeMatrix, 8);
        end = System.nanoTime();
        System.out.println("Паралельное умножение: " + ((double)(end-start)/1000000) + " миллисекунд");
        //sumMatrix.output();
    }
}

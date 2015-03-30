class RunData {
    int begin;
    int finish;
}

class GetSimple {
    public static void main(String args[]) {
        RunData data = new RunData();

        data.begin = 1;
        data.finish = 100;

        System.out.println("Простые числа в диапазоне от " + data.begin + " до " + data.finish + ":");
        int count = 0;

        for(int i = data.begin; i < data.finish; i++) {

            int division = 0;
            for(int j = data.begin; j <= i; j++) {
                if ( i % j == 0) {
                    division++;
                    if(division > 2) break;
                }
            }

            if(division == 2){
                count++;
                if(count == 1) System.out.print(i);
                else System.out.print(", " + i);
            }
        }

        System.out.println("\nВсего простых чисел: " + count);
    }
}


import java.util.Scanner;

/**
 * User: Oleg Astappev
 * Date: 15.10.14
 * Time: 17:19
 */
public class Romb {
    public static void main(String args[]) {

        System.out.println("Введите сторону ромба:");
        Scanner input = new Scanner( System.in );
        int n = input.nextInt();

        if(n%2 == 0) n--; //Что бы не заморачиваться с двумя точками, мы будем брать всегда нечетное.

        int center = n / 2;
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                if(i <= center) { // Верхняя часть
                    if(j >= center - i && j <= center + i) {
                        System.out.print("*");
                    } else {
                        System.out.print(" ");
                    }
                } else { // Нижняя часть
                    if(j >= center + i - n + 1 && j <= center - i + n - 1){
                        System.out.print("*");
                    } else {
                        System.out.print(" ");
                    }
                }
            }
            System.out.println();
        }

    }
}

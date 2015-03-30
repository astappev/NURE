import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

abstract class Figure {
    String name;
    String description;
    int[] current_pos = new int[2];

    Figure(String name) {
        this.name = name;
        this.description = "Описание фигуры " + name;
        System.out.println("Создана фигура: " + name);
    }

    Figure(String name, int x, int y) {
        this.name = name;
        this.current_pos[0] = x;
        this.current_pos[1] = y;
        this.description = "Описание фигуры " + name;
        System.out.println("Создана фигура: " + name);
    }

    /*public boolean equals(Figure obj){
        return Arrays.equals(this.current_pos, obj.current_pos);
    }*/


    public boolean equals(Object obj){
        if (this == obj) return true;
        if (!(obj instanceof Figure)) return false;

        Figure that = (Figure) obj;
        return Arrays.equals(this.current_pos, that.current_pos);
    }

    @Override
    public String toString() {
        return "Название фигуры: " + name;
    }

    /*public void name() {
        System.out.println("Название фигуры: " + name);
    }*/

    abstract public void output();
}

class Horse extends Figure {


    Horse() {
        super("Конь");
    }

    Horse(int x, int y) {
        super("Конь", x, y);
    }

    int[][] start_pos = {{0, 1}, {0, 6}};

    public void output() {
        System.out.println(description);
        System.out.println("Стартовая позиция " + (start_pos[0][0]+1) + "," + (start_pos[0][1]+1) + " и " + (start_pos[1][0]+1) + "," + (start_pos[1][1]+1));
    }
}

class Rook extends Figure {
    Rook() {
        super("Ладья");
    }

    Rook(int x, int y) {
        super("Ладья", x, y);
    }

    public void output() {
        System.out.println(description);
    }
}

public class Chess {
    public static void main(String args[]) {
        Set<Figure> white = new HashSet<Figure>();
        Set<Figure> balack = new HashSet<Figure>();

        /*Horse horse = new Horse();
        white.add(horse);
        balack.add(horse);*/

        /*balack.add(new Rook(3, 4));
        white.add(new Rook(3, 4));*/

        Horse horse = new Horse(3, 4);
        Rook rook = new Rook(5, 4);

        /*for(Figure entry : white) {
            entry.name();
            entry.output();
        }*/

        if(!horse.equals(rook)) {
            System.out.println("Позиции не равны.");
        } else {
            System.out.println("Позиции равны.");
        }

        System.out.print(rook);
    }
}

/* Equals, Hash
Сравнить позиции на 2-х досках
Obj в параметр equals
 */
package Java_Basics_Exercise;

import java.util.Scanner;

public class E03_ReverseCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char firstChar = scanner.next().charAt(0);
        char secondChar = scanner.next().charAt(0);
        char thirdChar = scanner.next().charAt(0);

        System.out.printf("%s%s%s", thirdChar, secondChar, firstChar);
    }
}

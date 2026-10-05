namespace Assignment6_1 {
    internal class ArrayFuncs {

        public static void MoveZerosToEnd(int[] numbers) {

            int nextSpot = 0;

            for (int spot = 0; spot < numbers.Length; spot++) {

                if (numbers[spot] == 0)
                    continue;

                int hold = numbers[nextSpot];
                numbers[nextSpot] = numbers[spot];
                numbers[spot] = hold;

                nextSpot++;

            }
        }
    }
}

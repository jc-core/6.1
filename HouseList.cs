namespace Assignment6_1 {
    internal class HouseList {

        private House? first;
        private House? last;

        public int Count { get; private set; }

        public void AddLast(int number, string address, string style) {

            House house = new House(number, address, style);

            if (last == null) {
                first = house;
                last = house;
            }
            else {
                last.Next = house;
                last = house;
            }

            Count++;

        }

        public House? Search(int number) {

            House? current = first;

            while (current != null) {

                if (current.Number == number)
                    return current;

                current = current.Next;

            }

            return null;

        }

        public void Display() {

            House? current = first;

            while (current != null) {

                Console.WriteLine($"  {current.Number,-8}{current.Address,-30}{current.Style}");
                current = current.Next;

            }
        }
    }
}

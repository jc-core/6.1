namespace Assignment6_1 {
    internal class House {

        public int Number { get; set; }
        public string Address { get; set; }
        public string Style { get; set; }
        public House? Next { get; set; }

        public House(int number, string address, string style) {

            Number = number;
            Address = address;
            Style = style;

        }
    }
}

using System.Globalization;

namespace ExceptionExemple.Entities {
    class VectorIsChar {

        public char[] Characters = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                                 'u', 'v', 'x', 'w', 'y', 'z'};

        public VectorIsChar() { }

        public double IsChar(string acc) {

            for (int i = 0; i < acc.Length; i++) {

                for (int j = 0; j < Characters.Length; j++) {

                    if (acc[i] == Characters[j]) {

                        return 0.0;
                    }
                }
            }

            double value = double.Parse(acc, CultureInfo.InvariantCulture);
            return value;
        }
    }
}

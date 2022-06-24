using System;

namespace cSharpSillyBot.CommandCode {
    class Date {

        Object[,] months = new Object[,] {{"January", 31}, {"Feburary", 28}, {"March", 31},
                                        {"April", 30}, {"May", 31}, {"June", 30}, {"July", 31},
                                        {"August", 31}, {"September", 30}, {"October", 31},
                                        {"November", 30}, {"December", 31}};

        public int getCurrentDay() {
            return DateTime.Now.Day;
        }
        public int getCurrentMonth() {
            return DateTime.Now.Month;
        }

        public int getBetween(int current, int past) {
            int difference = 0;
            for (int i = past; i<current-1; i++) {
                difference += (int)months[i, 1];
            }
            return difference + getCurrentDay();
        }

        public int getTill(int current, int future) {
            int difference = 0;
            for(int i = current-1; i<future; i++) {
                difference += (int)months[i, 1];
            }
            return -1*(difference - getCurrentDay() + 1);
        }

        public string getDate(int month) {
            int past = getBetween(getCurrentMonth(), month-1) * ((month<=getCurrentMonth()) ? 1 : 0);
            int future = getTill(getCurrentMonth(), month-1) * ((month>getCurrentMonth()) ? 1: 0);
            return $"{months[(month-1), 0]} {past + future}";
        }

        public string getAll() {
            string message = string.Empty;
            for (int i = 1; i<months.GetLength(0)+1; i++) {
                message += $"{getDate(i)}\n";
            }
            return message;
        }

        public string randomDate() {
            return "";
        }
    }
}
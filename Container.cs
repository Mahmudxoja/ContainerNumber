using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerNumber
{
    /*
     * The number of a large-capacity container consists of 11 characters, 
     * including 4 letters and 7 digits(for example, OOLU1263890).
     * 
     * Room medium container consists of 9 digits(e.g. 318100531).
     * 
     * */
    static class Container
    {
        public enum ContainerLetters
        {
            A = 10,
            B = 12,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L = 23,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V = 34,
            W,
            X,
            Y,
            Z
        }

        /// <summary>
        /// Get type container. 
        /// </summary>
        /// <param name="container_number"></param>
        /// <returns>Containr type (large or medium). If container number wrong return null</returns>
        public static string TypeContainer(string container_number)
        {
            if (container_number.Length == 9)
            {
                for (int i = 0; i < container_number.Length; i++)
                {
                    if (!char.IsDigit(container_number[i]))
                        return null;
                }
                return "medium";
            }
            else if (container_number.Length == 11)
            {
                /* 
                 * Number medium container must consist of 9 digits, 
                 * large container: 4 letters and 7 digits.
                 * */
                for (int i = 0; i < container_number.Length; i++)
                {
                    if (i < 4 && !char.IsLetter(container_number[i]))
                        return null;

                    if (i >= 4 && !char.IsDigit(container_number[i]))
                        return null;
                }

                return "large";
            }

            return null;
        }

        /// <summary>
        /// Convert from letter to number
        /// </summary>
        /// <param name="c">Letter from container code (number)</param>
        /// <returns>Letter value</returns>
        public static int FromLetterToDigit(string c)
        {
            ContainerLetters test = (ContainerLetters)Enum.Parse(typeof(ContainerLetters), c);
            return (int)test;
        }

        /// <summary>
        /// Check large container number.
        /// </summary>
        /// <param name="container_number">Container number (4 letters and 7 digits)</param>
        /// <param name="true_last_number">Correctly last number</param>
        /// <returns>Number of container is true or false</returns>
        public static bool LargeContainer(string container_number, out int true_last_number)
        {
            string last_number = container_number[container_number.Length - 1].ToString();

            // Math.Pow return double type, so variable sum is double
            double sum = 0;

            for (int i = 0; i < 10; i++)
            {
                double temp = 0;
                if (char.IsLetter(container_number[i]))
                    temp = FromLetterToDigit(container_number[i].ToString()) * Math.Pow(2, i);
                else
                    temp = Convert.ToInt32(container_number[i].ToString()) * Math.Pow(2, i);
                sum += temp;
            }

            if (sum % 11 == 10)
            {
                true_last_number = 0;
                return 0 == Convert.ToInt32(last_number);
            }

            true_last_number = Convert.ToInt32(sum % 11);
            return sum % 11 == Convert.ToInt32(last_number);
        }


        /// <summary>
        /// Check medium container number.
        /// </summary>
        /// <param name="container_number">Container number (9 digits)</param>
        /// <param name="true_last_number">Correctly last number</param>
        /// <returns>Number of container is true or false</returns>
        public static bool MediumContainer(string container_number, out int true_last_number)
        {
            string last_number = container_number[container_number.Length - 1].ToString();

            // Math.Pow return double type, so variable sum is double
            double sum = 0;

            for (int i = 0; i < 8; i++)
                sum += Convert.ToInt32(container_number[i].ToString()) * Math.Pow(2, i);

            if (sum % 11 == 10)
            {
                true_last_number = 0;
                return 0 == Convert.ToInt32(last_number);
            }

            true_last_number = Convert.ToInt32(sum % 11);
            return sum % 11 == Convert.ToInt32(last_number);
        }
    }
}

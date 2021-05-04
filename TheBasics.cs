using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTutorial
{
    public class TheBasics
    {

        public enum ErrorMessages
        {
            DenominatorCantBeZero,
            NumeratorNotANumber,
            DemoninatorNotANumber,
            HttpConnectionError,
            GeneralException,
            OK

        }

        public static int DivideTwoNumbers(int numerator, int denominator)
        {

            return (numerator / denominator);

        }

        public static int DivideTwoNumbersWithHandling(int numerator, int denominator)
        {
            try
            {

                return (numerator / denominator);
            }
            catch (Exception e)
            {
                LogTransactions();
                //Display it
                Console.WriteLine(e.Message.ToString());

            }





            return 0;
        }

        public static (ErrorMessages, int) DivideTwoNumbersWithHandlingFinally(int numerator, int denominator)
        {
            int answer = 0;
            ErrorMessages em;
            try
            {
                CreateConnection();
                answer = (numerator / denominator);
                PushResultToDatabase(answer);
                em = ErrorMessages.OK;
            }
            catch (Exception e)
            {
                LogTransactions();
                //Display it
                Console.WriteLine(e.Message.ToString());
                em = ErrorMessages.DenominatorCantBeZero;
            }
            finally
            {
                TerminateConnection();
            }
            return (em,answer);
            
        }

        public static (ErrorMessages,int) ValidateNumbersAndDivide(int Numerator, int Denominator)
        {

            if (Denominator == 0)
            {
                return (ErrorMessages.DenominatorCantBeZero, 0);
            }
            else
            {
                return (ErrorMessages.OK, DivideTwoNumbersWithHandling(Numerator, Denominator));
            }

        }

        public static int CanYouDoThis(int Numerator, int Denominator)
        {
            int answer = 0;
            
            try
            {
                   CreateConnection();
                   answer = (Numerator / Denominator);
            }
            catch
            {
                return 1;
            }
            finally
            {
                TerminateConnection();
            }
            return answer;

        }

        /// <summary>
        /// Fake create connection
        /// </summary>
        public static void CreateConnection() 
        {

        }

        /// <summary>
        /// Fake Terminate Connection
        /// </summary>
        public static void TerminateConnection()
        {

        }

        //Fake Logging
        public static void LogTransactions()
        {

        }

        //Fake Database Connection
        public static void PushResultToDatabase(int Result)
        {

        }

    }
}

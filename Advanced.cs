using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TryCatchFinallyThrowTutorial;
using static ExceptionTutorial.TheBasics;

namespace MathTesting
{
    public class Advanced
    {

  
        ///Can you have more than one catch?
        public static (ErrorMessages,int) DivideWithMultipleCatches(int Numerator, int Denominator)
        {

            int answer = 0;
            ErrorMessages em;
            try
            {
                CreateConnection();
                answer = (Numerator / Denominator);
                PushResultToDatabase(answer);
                em = ErrorMessages.OK;
            }
            catch (DivideByZeroException e)
            {
                LogTransactions();
                //Display it
                Console.WriteLine(e.Message.ToString());
                em = ErrorMessages.DenominatorCantBeZero;
            }
            catch (HttpResponseException e)
            {
                LogTransactions();
                //Display it
                Console.WriteLine(e.Message.ToString());
                em = ErrorMessages.HttpConnectionError;
            }
            catch (Exception e)
            {
                LogTransactions();
                //Display it
                Console.WriteLine(e.Message.ToString());
                em = ErrorMessages.GeneralException;
            }
            finally
            {
                TerminateConnection();
            }
            return (em, answer);


        }


        public static int DivideWithFinally(int Numerator, int Denominator)
        {
            int answer = 0;
            try
            {
                CreateConnection();
                answer = (Numerator / Denominator);
                PushResultToDatabase(answer);
            }
            finally
            {
                TerminateConnection();
            }

            /*
            using (CreateConnection())
            {
                answer = (Numerator / Denominator);
                PushResultToDatabase(answer);
            }
            */

            return answer;
        }

        public static int DontDoThis(int Numerator, int Denominator)
        {
            int answer = 0;
            try
            {
                answer = (Numerator / Denominator);
            }
            catch
            {

            }
            return answer;

        }

    }
}

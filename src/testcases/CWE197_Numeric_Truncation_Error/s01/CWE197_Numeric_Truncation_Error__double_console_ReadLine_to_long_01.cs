/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__double_console_ReadLine_to_long_01.cs
Label Definition File: CWE197_Numeric_Truncation_Error__double.label.xml
Template File: sources-sink-01.tmpl.cs
*/
/*
* @description
* CWE: 197 Numeric Truncation Error
* BadSource: console_ReadLine Read data from the console using ReadLine
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* BadSink: to_long Convert data to a long
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE197_Numeric_Truncation_Error
{

class CWE197_Numeric_Truncation_Error__double_console_ReadLine_to_long_01 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */

        public void test()
        {
            double inputNumber = 1234.56789;
            long data = (long)inputNumber;
            IO.WriteLine(data);
        }
    public override void Bad()
    {
        double data;
        data = double.MinValue; /* Initialize data */
        {
            /* read user input from console with ReadLine */
            try
            {
                /* FLAW: Read data from the console using ReadLine */
                string stringNumber = Console.ReadLine();
                if (stringNumber != null) // avoid NPD incidental warnings
                {
                    try
                    {
                        data = double.Parse(stringNumber.Trim());
                    }
                    catch(FormatException exceptNumberFormat)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - uses goodsource and badsink */
    private void GoodG2B()
    {
        double data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }
#endif //omitgood
}
}

namespace AdventOfCode23.Day1;

public class CalibrationSolver
{
    string[] _spelledDigits = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    char[] _spelledDigitsFirstChar = { 'o', 't', 'f', 's', 'e', 'n' };
    int _spelledMaxLength = 5;
    
    public int SolveString(string calibrationString, bool canSpellDigits)
    {
        string[] calibrationArr = SplitString(calibrationString);

        int result = 0;
        foreach (string calibrationLine in calibrationArr)
        {
            if (canSpellDigits)
            {
                result += SolveWithSpelledDigits(calibrationLine);   
            }
            else
            {
                result += SolveCalibrationLine(calibrationLine);
            }
        }
        return result;
    }

    private string[] SplitString(string calibrationString)
    {
        return calibrationString.Split(
            new string[] { Environment.NewLine },
            StringSplitOptions.None
        );
    }

    private int SolveCalibrationLine(string calibrationLine)
    {
        char firstDigit = '0';
        char lastDigit = '0';
        for (int i = 0; i < calibrationLine.Length; i++)
        {
            if (Char.IsDigit(calibrationLine[i]))
            {
                firstDigit = calibrationLine[i];
                break;
            }
        }
            
        for (int i = calibrationLine.Length - 1; i >= 0; i--)
        {
            if (Char.IsDigit(calibrationLine[i]))
            {
                lastDigit = calibrationLine[i];
                break;
            }
        }

        return Int32.Parse(firstDigit.ToString() + lastDigit.ToString());
    }
    
    private int SolveWithSpelledDigits(string calibrationLine)
    {
        char firstDigit = CalculateFirstDigit(calibrationLine);
        char lastDigit = CalculateLastDigit(calibrationLine);
        return Int32.Parse(firstDigit.ToString() + lastDigit.ToString());
    }

    private char CalculateFirstDigit(string calibrationLine)
    {
        for (int i = 0; i < calibrationLine.Length; i++)
        {
            char curChar = calibrationLine[i];
            if (Char.IsDigit(curChar))
            {
                return curChar;
            }

            if (Array.IndexOf(_spelledDigitsFirstChar, curChar) > -1)
            {
                int wordLength = i + _spelledMaxLength > calibrationLine.Length ? calibrationLine.Length - i : _spelledMaxLength;      
                string lineSlice = calibrationLine.Substring(i, wordLength);
                for (int x = 0; x < _spelledDigits.Length; x++)
                {
                    if (lineSlice.StartsWith(_spelledDigits[x]))
                    {
                        return (x + 1).ToString()[0];
                    }
                }
            }
        }
        return '0';
    }

    private char CalculateLastDigit(string calibrationLine)
    {
        for (int i = calibrationLine.Length - 1; i >= 0; i--)
        {
            char curChar = calibrationLine[i];
            if (Char.IsDigit(curChar))
            {
                return curChar;
            }

            if (Array.IndexOf(_spelledDigitsFirstChar, curChar) > -1)
            {
                int wordLength = i + _spelledMaxLength > calibrationLine.Length ? calibrationLine.Length - i : _spelledMaxLength;      
                string lineSlice = calibrationLine.Substring(i, wordLength);
                for (int x = 0; x < _spelledDigits.Length; x++)
                {
                    if (lineSlice.StartsWith(_spelledDigits[x]))
                    {
                        return (x + 1).ToString()[0];
                    }
                }
            }
        }
        return '0';
    }
}
namespace AdventOfCode23.Day1;

public class CalibrationSolver
{
    public int SolveString(string calibrationString)
    {
        string[] calibrationArr = SplitString(calibrationString);

        int result = 0;
        foreach (string calibrationLine in calibrationArr)
        {
            result += SolveCalibrationLine(calibrationLine);
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
}
/*
Calculates students final score as the average exam grade + extra credit scores (worth 10% of an exam grade).
Then prints the results in a specified format.
*/

int studentCount = 0;
int scoreCount = 0;

// Get number of students
do
{
    Console.Write("Number of students: ");
}
while (!Int32.TryParse(Console.ReadLine(), out studentCount));

// Get number of grades
do
{
    Console.Write("Number of grades: ");
}
while (!Int32.TryParse(Console.ReadLine(), out scoreCount));

// [0] -> exam score (average), [1] -> extra credit (average), [2] -> extra credit (points)
Dictionary<string, decimal[]> students = new Dictionary<string, decimal[]>();

// Populate students with names and grades
for (int i = 0; i < studentCount; i++)
{
    // Name
    string name = "";
    Console.Write("Student name: ");
    name = Console.ReadLine().ToString();

    // Exam score
    int score = 0;
    int scoreSum = 0;

    for (int j = 0; j < scoreCount; j++)
    {
        Console.Write($"{name}'s exam score {j + 1}: ");
        score = Int32.Parse(Console.ReadLine());
        scoreSum += score;
    }

    // Extra credit scores
    bool noMoreExtraCreditScores = false;
    int extraCreditScoresCount = 0;
    int extraCreditScore = 0;
    int extraCreditSum = 0;

    do
    {
        Console.Write($"Are there extra credit scores for {name}? [y/n] ");
        string confirmation = Console.ReadLine();

        if (confirmation.ToLower() != "y")
        {
            noMoreExtraCreditScores = true;
        }

        if (!noMoreExtraCreditScores)
        {
            Console.Write($"{name}'s extra credit score {extraCreditScoresCount + 1}: ");
            extraCreditScore = Int32.Parse(Console.ReadLine());
            extraCreditSum += extraCreditScore;
            extraCreditScoresCount++;
        }
    } while (!noMoreExtraCreditScores);

    // Final scores
    decimal averageExamScore = (decimal)scoreSum / scoreCount;
    decimal extraCreditPoints = ((decimal)extraCreditSum / 10) / scoreCount; // Each score worth 10% of an exam score and later added to the average exam score
    decimal extraCreditAverage = (decimal)extraCreditSum / extraCreditScoresCount;

    decimal[] allScoreData = { averageExamScore, extraCreditAverage, extraCreditPoints };

    students.Add(name, allScoreData);
}

Console.WriteLine();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit");
Console.WriteLine();

foreach (KeyValuePair<string, decimal[]> student in students)
{
    string letterGrade = "";
    decimal overallGrade = student.Value[0] + student.Value[2]; // Average exam score + extra credit points

    if (overallGrade >= 97)
    {
        letterGrade = "A+";
    }
    else if (overallGrade >= 93)
    {
        letterGrade = "A";
    }
    else if (overallGrade >= 90)
    {
        letterGrade = "A-";
    }
    else if (overallGrade >= 87)
    {
        letterGrade = "B+";
    }
    else if (overallGrade >= 83)
    {
        letterGrade = "B";
    }
    else if (overallGrade >= 80)
    {
        letterGrade = "B-";
    }
    else if (overallGrade >= 77)
    {
        letterGrade = "C+";
    }
    else if (overallGrade >= 73)
    {
        letterGrade = "C";
    }
    else if (overallGrade >= 70)
    {
        letterGrade = "C-";
    }
    else if (overallGrade >= 67)
    {
        letterGrade = "D+";
    }
    else if (overallGrade >= 63)
    {
        letterGrade = "D";
    }
    else if (overallGrade >= 60)
    {
        letterGrade = "D-";
    }
    else
    {
        letterGrade = "F";
    }


    Console.Write($"{student.Key}:\t\t{student.Value[0].ToString("0.0")}\t\t{overallGrade.ToString("0.00")}\t{letterGrade}\t");
    Console.WriteLine($"{student.Value[1].ToString("0.0")} ({student.Value[2].ToString("0.00")})");
}

Console.WriteLine("Press ENTER to continue...");
Console.ReadLine();
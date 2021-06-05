using System;
using System.Text;

namespace EasyDoc.Application.Models
{
    public class ProgressBar
    {
        public int CurrentStep { get; set; }
        public int Length { get; set; }

        public ProgressBar(int length)
        {
            Length = length;
        }

        public ProgressBar(int length, int currentStep)
        {
            Length = length;
            CurrentStep = currentStep;
        }

        public void ShowProgress()
        {
            var placeHolder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                if (i < CurrentStep)
                {
                    placeHolder.Append('#');
                }
                else
                {
                    placeHolder.Append(' ');
                }
            }

            Console.Write("[{0}]", placeHolder.ToString());
            if(CurrentStep != Length)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            } else
            {
                Console.WriteLine();
            }
        }

        public bool Update()
        {
            if (CurrentStep < Length)
            {
                CurrentStep++;
                return true;
            }
            return false;
        }
    }
}

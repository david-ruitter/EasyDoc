using System;
using System.Text;

namespace EasyDoc.Application.Models
{
    public class ProgressBar
    {
        public string ProgressIndicator { get; set; } = "#";

        private int currentStep;
        public int CurrentStep
        {
            get
            {
                return currentStep;
            }
            set
            {
                if (value > Length)
                    throw new ArgumentException("CurrentStep exceeds the total Length");
                currentStep = value;
            }
        }
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

        public ProgressBar(int length, int currentStep, string progressIndicator)
        {
            Length = length;
            CurrentStep = currentStep;
            ProgressIndicator = progressIndicator;
        }

        public void ShowProgress()
        {
            Console.Write("[{0}]", GetProgress());
            if(CurrentStep != Length)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            } else
            {
                Console.WriteLine();
            }
        }

        public string GetProgress()
        {
            var placeHolder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                if (i < CurrentStep)
                {
                    placeHolder.Append(ProgressIndicator);
                }
                else
                {
                    placeHolder.Append(' ');
                }
            }
            return placeHolder.ToString();
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

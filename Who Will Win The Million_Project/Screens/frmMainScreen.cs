using System;
using System.Windows.Forms;
using MyLib;
using Game;
using System.Drawing;
using Who_Will_Win_The_Million_Game.Screens;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Who_Will_Win_The_Million_Game
{
    public partial class frmMainScreen : Form
    {

    [Serializable]
        public class clsGameProgress
        {
            public byte Level;
            public clsGame Game = new clsGame();
            public bool CloseProgram = true;
            public bool Lose = false;
            public bool AnswerValidated = false;
            
            public bool RemovedAnswers = false;
            public bool IsQuestionSwitched = false;
            public bool _Mute = false;
        }

        clsGameProgress CurrentGameProgress;
        private short[] _arrRemovedButtons = new short[2];
        private short _CountRemovedOptions;
        bool LoadedSavedGame;
        private frmIntro frm1;

        private void LoadSavedGameInfo()
        {
            StartGame();
            ChangeLevelUp(true);
            lblCurrentBalanceMoney.Text =  AddBalanceBasedOnLevel(true).ToString();
            muteToolStripMenuItem.Checked = CurrentGameProgress._Mute;
            btnSwitchQuestion.Enabled = !CurrentGameProgress.IsQuestionSwitched;

            btnRemove2Questions.Enabled = !CurrentGameProgress.RemovedAnswers;

            if(CurrentGameProgress.RemovedAnswers)
            _Remove2Answers();

         }

        public frmMainScreen(frmIntro frmLifeCycle,clsGameProgress SavedProgress = null)
        {
            InitializeComponent();
            frm1 = frmLifeCycle;

            CurrentGameProgress = SavedProgress ?? new clsGameProgress();
            LoadedSavedGame = (SavedProgress != null);

            this.StartPosition = FormStartPosition.CenterScreen;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero)) // Get Current Windows Display DPI , we used using for Graphics because it is non managed resource and we must dispose it to deallocate it from memory and by that using automatically dipose it .
            {
                float dpiX = g.DpiX;
                // dpix / 96f to have the display scale and * 100 to have it in percentage like 1.75 to be 175 .
                if (((dpiX / 96f) * 100) > 100)
                {
                    this.WindowState = FormWindowState.Maximized;
                    foreach(Control C in this.Controls)
                    {
                        if(C!=groupBox1 && C!= pbpButtonsArea && C!=pnlResponsiveness)
                        C.Size = new Size(C.Width - 70,C.Height-200);
                    }
                }
            }
        }

        private void frmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(CurrentGameProgress.CloseProgram)
                frm1.Close();
        }
        private void _ShowAnswer(Button Currentbtn, string Btn1Text, string Btn2Text, string Btn3Text)
        {
            CurrentGameProgress.Game.ShowAnswerOnButton(Currentbtn,Btn1Text,Btn2Text,Btn3Text);
        }
        private void _ShowQuestion()
        {
            CurrentGameProgress.Game.ShowQuestion(lblQuestion, CurrentGameProgress.Level);
        }
        private void StartGame()
        {
            _ShowQuestion();
            _ShowAnswer(btnAnswer1, btnAnswer2.Text, btnAnswer3.Text, btnAnswer4.Text);
            _ShowAnswer(btnAnswer2, btnAnswer1.Text, btnAnswer3.Text, btnAnswer4.Text);
            _ShowAnswer(btnAnswer3, btnAnswer1.Text, btnAnswer2.Text, btnAnswer4.Text);
            _ShowAnswer(btnAnswer4, btnAnswer1.Text, btnAnswer2.Text, btnAnswer3.Text);
            
        }

        private void ReSetPropertiesToConitinue()
        {
            CurrentGameProgress.Game.FoundCorrectAnswer = false;
            CurrentGameProgress.Game.CounterForShowingAnswers = 0;
            btnRemove2Questions.Enabled = true;
            _CountRemovedOptions = 0;
            _arrRemovedButtons = new short[2];
            hoverOrClickSound = true;
            btnRemove2Questions.Enabled = true;
            CurrentGameProgress.IsQuestionSwitched = false;
            btnSwitchQuestion.Enabled = true;
        }
        private void ContinueGame()
        {
            ReSetPropertiesToConitinue();
            StartGame();
            ReshowRemoveOptions();
        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            if (LoadedSavedGame)
                LoadSavedGameInfo();

            else
                StartGame();
        }
        void ChangeBtnColor(Button btn,Color C)
        {
            btn.BackColor = C;
        }
        void ChangeButtonsColor(Button Choosedbtn)
        {
            if (Choosedbtn.Text == CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer)
            {
                ChangeBtnColor(Choosedbtn, Color.DarkGreen);

                if (Choosedbtn.Tag != btnAnswer1.Tag)
                    ChangeBtnColor(btnAnswer1, Color.DarkRed);
                if (Choosedbtn.Tag != btnAnswer2.Tag)
                    ChangeBtnColor(btnAnswer2, Color.DarkRed);
                if (Choosedbtn.Tag != btnAnswer3.Tag)
                    ChangeBtnColor(btnAnswer3, Color.DarkRed);
                if (Choosedbtn.Tag != btnAnswer4.Tag)
                    ChangeBtnColor(btnAnswer4, Color.DarkRed);
            }
            else
            {
                ChangeBtnColor(Choosedbtn, Color.DarkRed);
            }
        }
        int AddBalanceBasedOnLevel(bool LoadingSavedGame = false)
        {
            byte CurrentLevel = CurrentGameProgress.Level;
            if (LoadingSavedGame)
                CurrentLevel--;

            switch (CurrentLevel + 1)
            {
                case 1:
                    return 100;
                case 2:
                    return 200;
                case 3:
                    return 400;
                case 4:
                    return 800;
                case 5:
                    return 1000;
                case 6:
                    return 2000;
                case 7:
                    return 4000;
                case 8:
                    return 8000;
                case 9:
                    return 16000;
                case 10:
                    return 32000;
                case 11:
                    return 65000;
                case 12:
                    return 125000;
                case 13:
                    return 250000;
                case 14:
                    return 500000;
                case 15:
                    return 1000000;
                default:
                    return 0;
            }
        }
        void ChangeLabelColor(Label lbl, Color BackColor,Color ForeColor)
        {
            lbl.BackColor = BackColor;
            lbl.ForeColor = ForeColor;
        }
        void ChangeLevelUp(bool SavedGameLoad = false)
        {
            switch (CurrentGameProgress.Level)
            {
                case 1:
                    ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    break;
                case 2:
                    ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    break;
                case 3:
                    ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 4:
                    ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 5:
                    ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 6:
                    ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 7:
                    ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 8:
                    ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 9:
                    ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 10:
                    ChangeLabelColor(lbl32Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 11:
                    ChangeLabelColor(lbl65Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl32Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 12:
                    ChangeLabelColor(lbl125Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl32Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl65Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 13:
                    ChangeLabelColor(lbl250Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl32Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl65Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl125Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 14:
                    ChangeLabelColor(lblHalfMillion, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl32Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl65Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl125Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl250Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
                case 15:
                    ChangeLabelColor(lblMillion, Color.Purple, Color.FromArgb(255, 250, 250, 250));

                    if (SavedGameLoad)
                    {
                        ChangeLabelColor(lbl100, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl200, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl400, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl800, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl1000, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl2Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl4Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl8Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl16Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl32Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl65Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl125Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lbl250Th, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                        ChangeLabelColor(lblHalfMillion, Color.Purple, Color.FromArgb(255, 250, 250, 250));
                    }
                    break;
            }
        }

        bool hoverOrClickSound = true;
        bool ValidateAnswer(Button btn)
        {
            btnSwitchQuestion.Enabled = false;
            btnRemove2Questions.Enabled = false;
            hoverOrClickSound = false ;
            if (btn.Text == CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer)
            {
                lblCurrentBalanceMoney.Text = AddBalanceBasedOnLevel().ToString() + " $";
                CurrentGameProgress.Level++;
                ChangeLevelUp();
                return true;
            }
            else
                return false;
         
        }
        void EndGame(string Title,string Balance)
        {
            File.Delete("CurrentGameProgress.bin");
            Form frmBalance = new frmBalanceCard(Title,Balance);
            frmBalance.ShowDialog();
            Form FrmStart = new frmIntro(frm1);
            //This Won't work because sometime the object reference still not disposed at the moment we are checking therefore the condition will be false
            //if (frmBalance.IsDisposed)
            //    {
            //    CloseProgram = false;
            //    this.Close();
            //    frm1.Show();
            //}
            CurrentGameProgress.CloseProgram = false;
            this.Close();
            FrmStart.Show();
        }
        private void CheckAnswer(Button btn)
        {
            if (CurrentGameProgress.Lose = (!ValidateAnswer(btn)))
            {
                if (!CurrentGameProgress._Mute)
                    clsLib.RunLoseOrLeaveSound();
                if(lblCurrentBalanceMoney.Text!="0 $")
                EndGame("You Lost 1 Million Prize , Congrats About What You Earned And Better Luck Next Time To Get The 1 Million Prize", lblCurrentBalanceMoney.Text);
                else
                    EndGame("You Lost The Game, Better Luck Next Time", lblCurrentBalanceMoney.Text);
            }
            else if (CurrentGameProgress.Level == 15)
            {
                if(!CurrentGameProgress._Mute)
                clsLib.RunWiningSound();
                EndGame("Congratulations , you Have Won The 1 Million Dollar Prize", lblCurrentBalanceMoney.Text);
            }

            if (!CurrentGameProgress.Lose)
            {
                ChangeButtonsColor(btn);
                tmGameCycle.Start();
            }
           
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer && !CurrentGameProgress._Mute)
                clsLib.RunWiningSound();

            else if (hoverOrClickSound && !CurrentGameProgress._Mute)
                clsLib.RunClickSound();

            if (!CurrentGameProgress.AnswerValidated)
            CheckAnswer((Button)sender);

            CurrentGameProgress.AnswerValidated = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tmGameCycle.Stop();
            CurrentGameProgress.AnswerValidated = false;
            ChangeBtnColor(btnAnswer1, Color.Purple);
            ChangeBtnColor(btnAnswer2, Color.Purple);
            ChangeBtnColor(btnAnswer3, Color.Purple);
            ChangeBtnColor(btnAnswer4, Color.Purple);
            if(CurrentGameProgress.Level !=15)
            ContinueGame();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGameProgress.CloseProgram = false;
            Form frmMain = new frmMainScreen(frm1);
            frmMain.Opacity = 100.0;
            frmMain.Show();
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                if (MessageBox.Show("Do you want to save current game progress?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _SaveCurrentProgress();
                }

            }
            this.Close();
        }

        
        bool CheckBtnIfIsRemoved(short BtnNumber)
        {
            if (_arrRemovedButtons[0]== BtnNumber)
                return true;

            if (_arrRemovedButtons[1] == BtnNumber)
                return true;

            return false;

        }
        void remove1Option()
        {
            short RandomNum = clsLib.GetARandomNumber(1, 5);

            switch (RandomNum)
            {
                case 1:
                    if ((btnAnswer1.Text != CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer) && !CheckBtnIfIsRemoved(1))
                    {
                        _arrRemovedButtons[_CountRemovedOptions] = 1;
                        btnAnswer1.Hide();
                        _CountRemovedOptions++;
                    }
                    else
                    {
                        remove1Option();
                    }
                    break;

                case 2:
                    if ((btnAnswer2.Text != CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer) && !CheckBtnIfIsRemoved(2))
                    {
                        _arrRemovedButtons[_CountRemovedOptions] = 2;
                        btnAnswer2.Hide();
                        _CountRemovedOptions++;
                    }
                    else
                    {
                        remove1Option();
                    }
                    break;

                case 3:
                    if ((btnAnswer3.Text != CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer) && !CheckBtnIfIsRemoved(3))
                    {
                        _arrRemovedButtons[_CountRemovedOptions] = 3;
                        btnAnswer3.Hide();
                        _CountRemovedOptions++;
                    }
                    else
                    {
                        remove1Option();
                    }
                    break;

                case 4:
                    if ((btnAnswer4.Text != CurrentGameProgress.Game.lQuestions[CurrentGameProgress.Game.CurrentQuestionNumber].RightAnswer) && !CheckBtnIfIsRemoved(4))
                    {
                        _arrRemovedButtons[_CountRemovedOptions] = 4;
                        btnAnswer4.Hide();
                        _CountRemovedOptions++;
                    }
                    else
                    {
                        remove1Option();
                    }
                    break;
            }
            
        }

        void ReshowOption(Button Btn)
        {
            if (!Btn.Visible)
                Btn.Show();
        }
        void ReshowRemoveOptions()
        {
            ReshowOption(btnAnswer1);
            ReshowOption(btnAnswer2);
            ReshowOption(btnAnswer3);
            ReshowOption(btnAnswer4);
            CurrentGameProgress.RemovedAnswers = false;
        }
        
        private void _Remove2Answers()
        {
            remove1Option();
            remove1Option();
        }

        private void btnRemove2Questions_Click(object sender, EventArgs e)
        {
            if (!CurrentGameProgress.RemovedAnswers)
            {
                btnRemove2Questions.Enabled = false;  

                if(!CurrentGameProgress._Mute)
                clsLib.RunClickSound();

                _Remove2Answers();
            }

            CurrentGameProgress.RemovedAnswers = true;
        }
        private void btnSwitchQuestion_Click(object sender, EventArgs e)
        {
            if(!CurrentGameProgress._Mute)
            clsLib.RunClickSound();

            if (!CurrentGameProgress.IsQuestionSwitched)
            {
                ContinueGame();
                CurrentGameProgress.IsQuestionSwitched = true;
                btnSwitchQuestion.Enabled = false;
            }
        }
        private void btnLeave_Click(object sender, EventArgs e)
        {
            if(!CurrentGameProgress._Mute)
            clsLib.RunLoseOrLeaveSound();

            if (MessageBox.Show("Are you sure you want to exit?\n", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                EndGame("You Left The Game , Congrats on What You have Earned And Better Luck Next Time To Get The 1 Million Prize", lblCurrentBalanceMoney.Text);
            }
        }
        private void Controls_MouseHover(object sender, EventArgs e)
        {
            if(hoverOrClickSound && !CurrentGameProgress._Mute)
            clsLib.RunHoverSound();
        }

        private void ColorForeChange_TSMI_DropDownOpening(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.Black;
        }
        private void ColorForeChange_TSMI_DropDownClosed(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.FromArgb(255,226,226,226);
        }
        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (muteToolStripMenuItem.Checked)
                CurrentGameProgress._Mute = true;
            else
                CurrentGameProgress._Mute = false;
        }

        private void _SaveCurrentProgress()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("CurrentGameProgress.bin", FileMode.Create))
            {
                formatter.Serialize(stream, CurrentGameProgress);
            }
        }

        private void tsmiSaveCurrentProgress_Click(object sender, EventArgs e)
        {
            _SaveCurrentProgress();
        }

        private void tsmiLoadSavedGame_Click(object sender, EventArgs e)
        {
            clsGameProgress SavedGame = null;
            if (frmIntro.LoadSavedGame(ref SavedGame))
            {
            CurrentGameProgress.CloseProgram = false;
            Form frmMain = new frmMainScreen(frm1, SavedGame);
            frmMain.Opacity = 100.0;
            frmMain.Show();
            this.Close();
            }


        }

        private void frmMainScreen_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void frmMainScreen_SizeChanged(object sender, EventArgs e)
        {

        }

        private void frmMainScreen_ResizeBegin(object sender, EventArgs e)
        {

        }


        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xF030;//SC means system command 
        private const int SC_RESTORE = 0xF120;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                int command = m.WParam.ToInt32() & 0xFFF0;
                if (command == SC_MAXIMIZE || command == SC_RESTORE)
                {
                    OnBeforeMaximize();
                }
                
            }

            base.WndProc(ref m);
        }

        private void OnBeforeMaximize()
        {
            this.Opacity = 0;
            
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (e, s) => {this.Opacity = 100; timer.Stop(); };
            timer.Start();
        }
   
    }
}
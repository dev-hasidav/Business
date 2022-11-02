namespace Business.Main.Timers
{
    partial class TimerTrigger
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tm = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.tm)).BeginInit();
            // 
            // tm
            // 
            this.tm.AutoReset = false;
            this.tm.Interval = 60000D;
            this.tm.Elapsed += new System.Timers.ElapsedEventHandler(this.tm_Elapsed);
            ((System.ComponentModel.ISupportInitialize)(this.tm)).EndInit();

        }

        #endregion

        private System.Timers.Timer tm;
    }
}

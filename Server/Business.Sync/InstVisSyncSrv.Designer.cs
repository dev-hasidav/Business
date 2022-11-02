namespace Business.Sync
{
    partial class InstVisSyncSrv
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
            this.si = new System.ServiceProcess.ServiceInstaller();
            this.spi = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // si
            // 
            this.si.DelayedAutoStart = true;
            this.si.Description = "Syncro server";
            this.si.DisplayName = "BusinessSyncSrv";
            this.si.ServiceName = "BusinessSyncSrv";
            // 
            // spi
            // 
            this.spi.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spi.Password = null;
            this.spi.Username = null;
            // 
            // InstVisSyncSrv
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.si,
            this.spi});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller si;
        private System.ServiceProcess.ServiceProcessInstaller spi;
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{


    public partial class ChangePasswordForm : Form
    {
        private TextBox oldPasswordTextBox;
        private TextBox newPasswordTextBox;
        private TextBox confirmNewPasswordTextBox;
        private Button changePasswordButton;
        private Button forgotPasswordButton;
        private Label oldPasswordLabel;
        private Label newPasswordLabel;
        private Label confirmNewPasswordLabel;

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize and configure the labels
            oldPasswordLabel = new Label { Text = "Old Password:", AutoSize = true };
            newPasswordLabel = new Label { Text = "New Password:", AutoSize = true };
            confirmNewPasswordLabel = new Label { Text = "Confirm New Password:", AutoSize = true };

            // Initialize and configure the text boxes
            oldPasswordTextBox = new TextBox { PasswordChar = '*' };
            newPasswordTextBox = new TextBox { PasswordChar = '*' };
            confirmNewPasswordTextBox = new TextBox { PasswordChar = '*' };

            // Initialize and configure the buttons
            changePasswordButton = new Button { Text = "Change Password" };
            forgotPasswordButton = new Button { Text = "Forgot Password?" };

            // Positioning controls (this will need adjustment to fit your UI layout)
            oldPasswordLabel.Location = new Point(10, 20);
            oldPasswordTextBox.Location = new Point(150, 20);
            newPasswordLabel.Location = new Point(10, 50);
            newPasswordTextBox.Location = new Point(150, 50);
            confirmNewPasswordLabel.Location = new Point(10, 80);
            confirmNewPasswordTextBox.Location = new Point(150, 80);
            changePasswordButton.Location = new Point(10, 110);
            forgotPasswordButton.Location = new Point(150, 110);

            // Setting the Size of text boxes and buttons
            oldPasswordTextBox.Size = newPasswordTextBox.Size = confirmNewPasswordTextBox.Size = new Size(200, 20);
            changePasswordButton.Size = new Size(130, 30);
            forgotPasswordButton.Size = new Size(130, 30);

            // Subscribe to button click events
            changePasswordButton.Click += ChangePasswordButton_Click;
            forgotPasswordButton.Click += ForgotPasswordButton_Click;

            // Add controls to the form
            Controls.Add(oldPasswordLabel);
            Controls.Add(oldPasswordTextBox);
            Controls.Add(newPasswordLabel);
            Controls.Add(newPasswordTextBox);
            Controls.Add(confirmNewPasswordLabel);
            Controls.Add(confirmNewPasswordTextBox);
            Controls.Add(changePasswordButton);
            Controls.Add(forgotPasswordButton);

            // Form settings
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 150);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            string oldPassword = oldPasswordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;
            string confirmNewPassword = confirmNewPasswordTextBox.Text;

            if (!InputValidation.IsValidPassword(newPassword))
            {
                // Валидация нового пароля
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("The new passwords do not match.");
                return;
            }

            /*if (!IsOldPasswordCorrect(oldPassword))
            {
                MessageBox.Show("The old password is incorrect.");
                return;
            }

            UpdatePasswordInDatabase(newPassword);*/
        }
        /*private bool IsOldPasswordCorrect(string oldPassword)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT pwd FROM User WHERE uid = @uid";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@uid", currentUsername);
                    var storedPassword = command.ExecuteScalar()?.ToString();

                    return HashPassword(oldPassword) == storedPassword;
                }
            }
        }
        private void UpdatePasswordInDatabase(string newPassword)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE User SET pwd = @newPwd WHERE uid = @uid";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newPwd", HashPassword(newPassword));
                    command.Parameters.AddWithValue("@uid", currentUsername);
                    command.ExecuteNonQuery();
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
                return hash;
            }
        }*/

        private void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
           
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }
    }
}

﻿using MCDFiscalManager.BusinessModel.Model;
using MCDFiscalManager.DataController;
using MCDFiscalManager.WinFormsInterface.UserDataSubForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MCDFiscalManager.WinFormsInterface
{
    public partial class UserDataForm : Form
    {
        UserDataController controller;
        public UserDataForm()
        {
            InitializeComponent();
        }
        public UserDataForm(UserDataController userController)
        {
            controller = userController ?? throw new ArgumentNullException(nameof(userController), Messages.ControllerNullExceptionMessage);
            InitializeComponent();
            userDataGridView.DataSource = controller.Elements ?? throw new ArgumentNullException(nameof(userController), Messages.ControllerCollectionNullExceptionMessage);
        }
        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (userDataGridView.SelectedRows.Count > 0)
            {
                int index = userDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(userDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                var element = from t in controller.Elements where t.ID == id select t;
                controller.RemoveElement(element.First());
                userDataGridView.DataSource = controller.Elements;
            }
        }

        private void addUserDataButton_Click(object sender, EventArgs e)
        {
            UserForm userAddForm = new UserForm();
            DialogResult dialogResult = userAddForm.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;

            var newUser = new User(userAddForm.nameTextBox.Text,
                                         userAddForm.surnameTextBox.Text,
                                         userAddForm.patronymicTextBox.Text);
            controller.AddElement(newUser);
            userDataGridView.DataSource = controller.Elements;
        }

        private void editUserDataButton_Click(object sender, EventArgs e)
        {
            if (userDataGridView.SelectedRows.Count > 0)
            {
                int index = userDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(userDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                var users = from t in controller.Elements where t.ID == id select t;
                User user = users.First();

                UserForm userAddForm = new UserForm();
                userAddForm.surnameTextBox.Text = user.Surname;
                userAddForm.nameTextBox.Text = user.Name;
                userAddForm.patronymicTextBox.Text = user.Patronymic;

                DialogResult dialogResult = userAddForm.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel) return;

                user.Surname = userAddForm.surnameTextBox.Text;
                user.Name = userAddForm.nameTextBox.Text;
                user.Patronymic = userAddForm.patronymicTextBox.Text;

                controller.UpdateElement(user);
                userDataGridView.DataSource = controller.Elements;
            }
        }
    }
}

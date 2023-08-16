using MVVMDemoWithMAUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemoWithMAUI.ViewModel
{
    public  class StudentListViewModel  : BaseViewModel
    {
        #region Properites
        public ObservableCollection<StudentModel> StudentList { get; set; } = new ObservableCollection<StudentModel>();
        #endregion


        public StudentListViewModel()
        {

            AddStudentList();
        }

        private void  AddStudentList()
        {
            IsBusy = true;
            Task.Run(async() =>
            {
                // await api call;
                await Task.Delay(1000);

                Application.Current.Dispatcher.Dispatch(() =>
                {
                    // adding data in Student List object
                    StudentList.Clear();
                    StudentList.Add(new StudentModel { Name = "jaidee", Address = "Thailand", Email = "abc@gmail.com" });
                    StudentList.Add(new StudentModel { Name = "meechai", Address = "Thailand", Email = "test@gmail.com" });
                    StudentList.Add(new StudentModel { Name = "chomjun", Address = "Thailand", Email = "1111@gmail.com" });
                    StudentList.Add(new StudentModel { Name = "sawat", Address = "Thailand", Email = "1234@gmail.com" });
                    StudentList.Add(new StudentModel { Name = "thailand", Address = "Thailand", Email = "2222@gmail.com" });
                    IsBusy = false; 
                });
            });
        }

        #region Commands
        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = false;
            AddStudentList();
        });

        public ICommand SelectedItemCommand => new Command<StudentModel>(async (studentDetail) =>
        {
            await App.Current.MainPage.DisplayAlert("Selected Student","Selected STudent Name is " + studentDetail.Name, "OK");
        });
        #endregion
    }
}

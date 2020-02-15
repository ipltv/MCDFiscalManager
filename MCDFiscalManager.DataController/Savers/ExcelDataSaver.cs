using MCDFiscalManager.BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Console;

namespace MCDFiscalManager.DataController.Savers
{
    public class ExcelDataSaver : IDataSaver, IDisposable
    {
        private Excel.Application excelApplication = new Excel.Application();
        
        public List<T> Load<T>() where T : class
        {
            
            if (typeof(T).FullName == typeof(OFD).FullName)
            {
                return OfdDataLoad(new FileInfo(@".\data\ofd.xlsx")).Cast<T>().ToList();
            }
            if (typeof(T).FullName == typeof(User).FullName)
            {
                return UserDataLoad(new FileInfo(@".\data\users.xlsx")).Cast<T>().ToList();
            }
            return null;
        }

        public void Save<T>(List<T> items) where T : class
        {
            if (typeof(T).FullName == typeof(OFD).FullName)
            {
                OfdDataSave(new FileInfo(@".\data\ofd.xlsx"), items.Cast<OFD>().ToList());
            }
            if (typeof(T).FullName == typeof(User).FullName)
            {
                UserDataSave(new FileInfo(@".\data\users.xlsx"), items.Cast<User>().ToList());
            }

        }

        private List<User> UserDataLoad(FileInfo dataFile)
        {
            List<User> result = new List<User>();
            Excel.Workbook workbook = excelApplication.Workbooks.Open(dataFile.FullName);
            Excel.Worksheet worksheet = workbook.Sheets[1];

            try
            {
                // TODO: Предусмотреть возможность инициализации из config файла.
                int i = 2;
                while (Convert.ToString(worksheet.Cells[i,1].Value2) != null)
                {
                    try
                    {
                        result.Add(new User(name: worksheet.Cells[i, 1].Value, 
                                            surname: worksheet.Cells[i, 2].Value,
                                            patronymic: worksheet.Cells[i, 3].Value));
                    }
                    catch
                    {
                        continue;
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                // TODO: Проработать обработку исключений
            }       
            finally
            {
                workbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            }
            return result;
        }
        private void UserDataSave(FileInfo dataFile, List<User> data)
        {

            try
            { 
                if (dataFile.Exists) dataFile.Delete();
                Excel.Workbook workbook = excelApplication.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets.Add();
                try
                {
                    worksheet.Cells[1, 1].Value2 = "Фамилия";
                    worksheet.Cells[1, 2].Value2 = "Имя";
                    worksheet.Cells[1, 3].Value2 = "Отчество";
                    int i = 2;
                    foreach(User user in data)
                    {
                        worksheet.Cells[i, 1].Value2 = user.Surname;
                        worksheet.Cells[i, 2].Value2 = user.Name;
                        worksheet.Cells[i, 3].Value2 = user.Patronymic;
                        i++;
                    }
                }
                catch(Exception ex)
                {
                    WriteLine(ex);
                }
                finally
                {
                    workbook.Close(true, dataFile.FullName);
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
        private List<OFD> OfdDataLoad(FileInfo dataFile)
        {
            List<OFD> result = new List<OFD>();
            Excel.Workbook workbook = excelApplication.Workbooks.Open(dataFile.FullName);
            Excel.Worksheet worksheet = workbook.Sheets[1];

            try
            {
                // TODO: Предусмотреть возможность инициализации из config файла.
                int i = 2;
                while (Convert.ToString(worksheet.Cells[i, 1].Value2) != null)
                {
                    try
                    {
                        result.Add(new OFD(tin: Convert.ToString(worksheet.Cells[i, 1].Value2), fullName: Convert.ToString(worksheet.Cells[i, 2].Value)));
                    }
                    catch
                    {
                        continue;
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Проработать обработку исключений\
                Console.WriteLine(ex);
            }
            finally
            {
                workbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            }
            return result;

        }
        private void OfdDataSave(FileInfo dataFile, List<OFD> data)
        {            
            try
            {
                if (dataFile.Exists) dataFile.Delete();
                Excel.Workbook workbook = excelApplication.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets.Add();
                try
                {
                    worksheet.Cells[1, 1].Value2 = "ИНН ОФД";
                    worksheet.Cells[1, 2].Value2 = "Полное наименование ОФД";
                    int i = 2;
                    foreach (OFD ofdItem in data)
                    {
                        worksheet.Cells[i, 1].Value2 = ofdItem.TIN;
                        worksheet.Cells[i, 2].Value2 = ofdItem.FullName;
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex);
                }
                finally
                {
                    workbook.Close(true,dataFile.FullName);
                }

            }
            catch (Exception ex)
            {
                WriteLine(ex); 
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                    excelApplication.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~ExcelDataSaver()
        // {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

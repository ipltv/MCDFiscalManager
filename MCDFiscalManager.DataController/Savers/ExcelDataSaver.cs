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
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet;

            //if (typeof(T).FullName == typeof(Address).FullName)
            //{
            //    FileInfo addresseDataFile = new FileInfo(@".\data\address.xlsx");
            //    workbook = excelApplication.Workbooks.Open(addresseDataFile.FullName);
            //    worksheet = workbook.Sheets[1];
            //    Dictionary<int, Address> addresses = AddressDataLoad(worksheet);
            //}
            if (typeof(T).FullName == typeof(Company).FullName)
            {
                FileInfo companyDataFile = new FileInfo(@".\data\company.xlsx");
                workbook = excelApplication.Workbooks.Open(companyDataFile.FullName);
                worksheet = workbook.Sheets[1];
                Dictionary<int, Company> company = CompanyDataLoad(worksheet);
            }

            if (typeof(T).FullName == typeof(OFD).FullName)
            {
                FileInfo ofdDataFile = new FileInfo(@".\data\ofd.xlsx");
                workbook = excelApplication.Workbooks.Open(ofdDataFile.FullName);
                worksheet = workbook.Sheets[1];
                return OfdDataLoad(worksheet).Cast<T>().ToList();
            }
            if (typeof(T).FullName == typeof(User).FullName)
            {
                FileInfo usersDataFile = new FileInfo(@".\data\users.xlsx");
                workbook = excelApplication.Workbooks.Open(usersDataFile.FullName);
                worksheet = workbook.Sheets[1];
                return UserDataLoad(worksheet).Cast<T>().ToList();
            }
            if (typeof(T).FullName == typeof(Store).FullName)
            {
                FileInfo storesDataFile = new FileInfo(@".\data\stores.xlsx");
                FileInfo companyDataFile = new FileInfo(@".\data\company.xlsx");
                FileInfo addresseDataFile = new FileInfo(@".\data\address.xlsx");

                workbook = excelApplication.Workbooks.Open(companyDataFile.FullName);
                worksheet = workbook.Sheets[1];
                Dictionary<int,Company> companyes = CompanyDataLoad(worksheet);

                workbook = excelApplication.Workbooks.Open(addresseDataFile.FullName);
                worksheet = workbook.Sheets[1];
                Dictionary<int, Address> addresses = AddressDataLoad(worksheet);

                workbook = excelApplication.Workbooks.Open(storesDataFile.FullName);
                worksheet = workbook.Sheets[1];
                return StoreDataLoad(worksheet, companyes, addresses).Cast<T>().ToList();
            }
            workbook?.Close(false);

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
        public Dictionary<int, Address> AddressDataLoad(Excel.Worksheet worksheet)
        {
            var result = new Dictionary<int, Address>();
            try
            {
                int i = 2;
                while (Convert.ToString(worksheet.Cells[i, 1].Value2) != null)
                {
                    try
                    {
                        result.Add(Convert.ToInt32(worksheet.Cells[i, 1].Value2), new Address(codeOfRegion: Convert.ToString(worksheet.Cells[i, 2].Value2),
                                                                                                      postcode: Convert.ToString(worksheet.Cells[i, 3].Value2) ?? "",
                                                                                                      district: Convert.ToString(worksheet.Cells[i, 4].Value2) ?? "",
                                                                                                      city: Convert.ToString(worksheet.Cells[i, 5].Value2) ?? "",
                                                                                                      locality: Convert.ToString(worksheet.Cells[i, 6].Value2) ?? "",
                                                                                                      street: Convert.ToString(worksheet.Cells[i, 7].Value2) ?? "",
                                                                                                      house: Convert.ToString(worksheet.Cells[i, 8].Value2) ?? "",
                                                                                                      building: Convert.ToString(worksheet.Cells[i, 9].Value2) ?? "",
                                                                                                      flat: Convert.ToString(worksheet.Cells[i, 10].Value2) ?? ""));
                    }
                    catch(ArgumentNullException nullEx)
                    {
                        WriteLine($"Для строки {i} не задано значение номера ПБО или один из параметров имеет недопустимое значение null. Параметр:{nullEx.ParamName}. Оригинальное сообщение:{Environment.NewLine}{nullEx}");
                    }
                    catch(ArgumentException argEx)
                    {
                        WriteLine($"Для одного ПБО задано 2 адреса. Повторение в строке {i}. Оригинальное сообщение:{Environment.NewLine}{argEx}");
                    }
                    catch(Exception ex)
                    {
                        WriteLine($"Возникла ошибка при чтении данных адреса в строке {i}. Оригинальное сообщение:{Environment.NewLine}{ex}");
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
            return result;
        }
        private Dictionary<int,Company> CompanyDataLoad(Excel.Worksheet worksheet)
        {
            var result = new Dictionary<int, Company>();
            try
            {
                int i = 2;
                while(Convert.ToString(worksheet.Cells[i,1].Value2) != null)
                {
                    try
                    {
                        result.Add(Convert.ToInt32(worksheet.Cells[i, 1].Value2), new Company(fullName: Convert.ToString(worksheet.Cells[i, 2].Value2),
                                                                                                        shortName: Convert.ToString(worksheet.Cells[i, 3].Value2),
                                                                                                        tin: Convert.ToString(worksheet.Cells[i, 4].Value2)));
                    }
                    catch(ArgumentNullException nullEx)
                    {
                        WriteLine($"Для строки {i} не задано значение номера компании или один из параметров имеет недопустимое значение null. Параметр:{nullEx.ParamName}. Оригинальное сообщение:{Environment.NewLine}{nullEx}");
                    }
                    catch (ArgumentException argEx)
                    {
                        WriteLine($"Повторение номера компании. Номер компании должен быть уникальным. Повторение в строке {i}. Оригинальное сообщение:{Environment.NewLine}{argEx}");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"Возникла ошибка при чтении данных адреса в строке {i}. Оригинальное сообщение:{Environment.NewLine}{ex}");
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
            return result;
        }
        private List<Store> StoreDataLoad(Excel.Worksheet worksheet, Dictionary<int,Company> company, Dictionary<int,Address> adresses)
        {
            List<Store> result = new List<Store>();
            try
            {
                int i = 2;
                while(Convert.ToString(worksheet.Cells[i,1].Value2) != null)
                {
                    result.Add(new Store(number:worksheet.Cells[i,1].Value2,
                                         name:worksheet.Cells[i,2].Value2,
                                         owner: company[Convert.ToInt32(worksheet.Cells[i,3].Value2)],
                                         trrc:worksheet.Cells[i,4].Value2,
                                         taxAuthoritiesCode:worksheet.Cells.Cells[i,5].Value2,
                                         address:adresses[Convert.ToInt32(worksheet.Cells[i,6].Value2)]));
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }
        private List<User> UserDataLoad(Excel.Worksheet worksheet)
        {
            List<User> result = new List<User>();
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
        private List<OFD> OfdDataLoad(Excel.Worksheet worksheet)
        {
            List<OFD> result = new List<OFD>();

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

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace The_Hangman_Game
{
    public class CapitalManager
    {

        public List<Capital> _listCapitals;
        public string _textFilePath = @"..\..\DATA\countries_and_capitals.txt";
        public Capital _currentSelected = null;

        /// <summary>
        /// Constructor - terminate creation of new list and loading data from file
        /// </summary>
        public CapitalManager()
        {
            CreateNewCapitalList();
            LoadDataFromTextFile();
        }

        /// <summary>
        /// Initialization capital list
        /// </summary>
        private void CreateNewCapitalList()
        {
            _listCapitals = new List<Capital>();
        }

        /// <summary>
        /// Parse data from file, separation char '|'
        /// </summary>
        public void LoadDataFromTextFile()
        {
            try
            {
                var fileStream = new FileStream(_textFilePath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var _splitCharIndex = line.IndexOf('|', 0);
                        _listCapitals.Add(new Capital { Country = line.Substring(0, _splitCharIndex - 1).TrimEnd().ToUpper(), City = line.Substring(_splitCharIndex + 1, line.Length - _splitCharIndex - 1).TrimStart().ToUpper() });
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Directory not found - " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found - " + ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine("File is corrupted - " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Coś poszło nie tak przy wczytywaniu pliku - " + ex.Message);
            }
            
        }

        /// <summary>
        /// Randomize number from 0 to max count of capital list
        /// </summary>
        /// <returns>Number - int</returns>
        public int Randomize()
        {
            return new Random().Next(0, _listCapitals.Count);
        }

        /// <summary>
        /// Select random capital with country from list of capitals
        /// </summary>
        /// <returns>Capital object</returns>
        public Capital SelectRandomCapital()
        {
            try
            {
                return _listCapitals[Randomize()];
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Argument out of range - " + ex.Message);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index out of range - " + ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("List not initialized - " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something were wrong - " + ex.Message);
            }
            return null;
        }
    }
}

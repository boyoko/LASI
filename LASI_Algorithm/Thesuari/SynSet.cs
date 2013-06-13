﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LASI.Algorithm.Thesauri
{
    public class SynSet
    {


        private HashSet<string> setWords;
        private HashSet<int> setPointers;


        //Aluan: I added this field to store some additional information I found in the WordNet files

        private WordNetNounCategory lexName;


        //Aluan: I added this Property to access some additional information I found in the WordNet files

        public WordNetNounCategory LexName {
            get {
                return lexName;
            }
        }

        //Aluan: I added this constructor to include some additional information I found in the WordNet files

        public SynSet(int ID, IEnumerable<string> words, IEnumerable<int> pointers, WordNetNounCategory lexCategory) {
            this.ID = ID;
            setWords = new HashSet<string>(words);
            setPointers = new HashSet<int>(pointers);
            lexName = lexCategory;

        }

        public SynSet(int ID, IEnumerable<string> words, IEnumerable<int> pointers) {

            this.ID = ID;
            setWords = new HashSet<string>(words);
            setPointers = new HashSet<int>(pointers);

        }




        public HashSet<string> Words {
            get {
                return setWords;
            }

        }

        public HashSet<int> Pointers {
            get {
                return setPointers;
            }
        }

        public int ID {
            get;
            private set;
        }

    }
}

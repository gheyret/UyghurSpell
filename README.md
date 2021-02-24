# UyghurSpell
Spellcheck module used in UyghurEditPP

# Samples

			UyghurSpell imla = new UyghurSpell();
			String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"uyghur_imla.txt");
			imla.LoadDictionary(path,Uyghur.YEZIQ.ULY);
			System.Diagnostics.Debug.WriteLine("Imla ambiridiki soz sani :" + imla.WordCount);
						
			string soz = "Uyghur";
			string barmu = imla.IsListed(soz)?"Bar":"Yoq";
			System.Diagnostics.Debug.WriteLine(soz + " Imla ambirida " + barmu);
			System.Diagnostics.Debug.WriteLine("======================================");

			//Barliq Uygh din bashlanghan sozlerni tepip chiqish
			List<string>  namzatlar = imla.GetSuggestions("Uygh*");
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}
			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "z?w??";
			System.Diagnostics.Debug.WriteLine("Izdeydighan qelip: " + soz);
			namzatlar = imla.GetSuggestions(soz);
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}

			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "a????mu";
			System.Diagnostics.Debug.WriteLine("Izdeydighan qelip: " + soz);
			namzatlar = imla.GetSuggestions(soz);
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}

			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "bugun";
			namzatlar = imla.Lookup(soz); // Xata sozning barliq namzatlirini izdep tapidu

			System.Diagnostics.Debug.WriteLine(soz + " ning namzatlirining sani : " + namzatlar.Count);
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}
			
			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "keldiya";
			namzatlar = imla.Lookup(soz); // Xata sozning barliq namzatlirini izdep tapidu

			System.Diagnostics.Debug.WriteLine(soz + " ning namzatlirining sani : " + namzatlar.Count);
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}

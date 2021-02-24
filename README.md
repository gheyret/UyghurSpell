# UyghurSpell
Spellcheck module used in UyghurEditPP

This program based [Spell Checker Dictionary Engine](https://www.codeproject.com/Articles/4179/Spell-Checker-Dictionary-Engine)

# Samples

			System.Diagnostics.Debug.WriteLine("Uyghurche Imla Tekshrush Programisi we uni Ishlitish!");
			System.Diagnostics.Debug.WriteLine("Ekanda korushke qolay bolushi uchun Latinche halette sinaymiz");
			UyghurSpell imla = new UyghurSpell();
			String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"uyghur_imla.txt");
			imla.LoadDictionary("uyghur_imla.txt",Uyghur.YEZIQ.ULY);
			System.Diagnostics.Debug.WriteLine("Imla ambiridiki soz sani :" + imla.WordCount);
						
			string soz = "Uyghur";
			string barmu = imla.IsListed(soz)?"Bar":"Yoq";
			System.Diagnostics.Debug.WriteLine(soz + " Imla ambirida " + barmu);
			System.Diagnostics.Debug.WriteLine("======================================");

			//Barliq Uygh din bashlanghan sozlerni izdep tapidu
			List<string>  namzatlar = imla.GetSuggestions("Uygh*");
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}
			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "z?w??"; //birinchi herp z, 3-herp w bolghan 5 herplik sozni izdep tapidu
			System.Diagnostics.Debug.WriteLine("Izdeydighan qelip: " + soz);
			namzatlar = imla.GetSuggestions(soz);
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}

			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "a????mu"; // a bilen bashlanghan, axiri mu bilen axirlashqan 7 herplik sozni izdep tapidu
			System.Diagnostics.Debug.WriteLine("Izdeydighan qelip: " + soz);
			namzatlar = imla.GetSuggestions(soz);
			foreach(string nam in namzatlar){
				System.Diagnostics.Debug.WriteLine(nam);
			}

			System.Diagnostics.Debug.WriteLine("======================================");
			soz = "bugun";
			namzatlar = imla.Lookup(soz); // bu yerde bugun degenni xata dep qarap, her xil ehtimaliqlarni kozde tutqan halda namzat sozlerni izdeydu

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

# Ijra netijisi

		Uyghurche Imla Tekshrush Programisi we uni Ishlitish!
		Ekanda korushke qolay bolushi uchun Latinche halette sinaymiz
		Imla ambiridiki soz sani :145768
		Uyghur Imla ambirida Bar
		======================================
		uyghurchilashturghuchi
		uyghurchilashturghan
		uyghurchilashturghili
		uyghurchilashturdi
		uyghurchilashturmaqchi
		uyghurchilashturmaq
		uyghurchilashturup
		uyghurchilashturush
		uyghurchilashturushni
		uyghurchilashturushqa
		uyghurchilashturushta
		uyghurchilashturushtin
		uyghurchilashturulghan
		uyghurchilashturuldi
		uyghurchilashturulup
		uyghurchilashturulush
		uyghurchilashturulmaq
		uyghurchilashti
		uyghurchilashqan
		uyghurchilashmaq
		uyghurchilishish
		uyghurchimu
		uyghurchini
		uyghurchinimu
		uyghurchining
		uyghurchigha
		uyghurchida
		uyghurchidimu
		uyghurchidin
		uyghurchidiki
		uyghurchisi
		uyghurchisimu
		uyghurchisini
		uyghurchisinimu
		uyghurchisining
		uyghurche
		uyghursoft
		uyghursoftning
		uyghurshunas
		uyghurshunasliq
		uyghurshunasliqning
		uyghurshunaslar
		uyghursiz
		uyghurluq
		uyghurluqni
		uyghurluqtin
		uyghurluqini
		uyghurla
		uyghurlar
		uyghurlarmu
		uyghurlarla
		uyghurlarchu
		uyghurlarning
		uyghurlarningmu
		uyghurlarningla
		uyghurlarningkige
		uyghurlarni
		uyghurlarnimu
		uyghurlarnila
		uyghurlargha
		uyghurlarghimu
		uyghurlarghila
		uyghurlarda
		uyghurlardimu
		uyghurlardin
		uyghurlardinmu
		uyghurlardiki
		uyghurlardek
		uyghurlardur
		uyghurliri
		uyghurlirimu
		uyghurlirim
		uyghurlirimiz
		uyghurlirimizmu
		uyghurlirimizni
		uyghurlirimizning
		uyghurlirimizdin
		uyghurlirimizgha
		uyghurlirini
		uyghurlirining
		uyghurliridin
		uyghurliridiki
		uyghurlirida
		uyghurlirigha
		uyghur’édit
		uyghur’éditning
		uyghuristan
		uyghuristanning
		uyghuristan’gha
		uyghuristanda
		uyghuristanliq
		uyghurimiz
		uyghurimizning
		uyghuri
		uyghurining
		uyghur
		uyghurmu
		uyghurmidu
		uyghurmiz
		uyghurmen
		uyghurken
		uyghurni
		uyghurning
		uyghurningmu
		uyghurghu
		uyghurgha
		uyghurda
		uyghurdin
		uyghurdiki
		uyghurdur
		uyghurdek
		uyghurum
		uyghurumni
		uyghurumning
		uyghurumdin
		uyghurumgha
		uyghun
		uyghunlashturup
		uyghunlashturush
		uyghunlashturushni
		uyghunlashturushqa
		uyghunlashturulghan
		uyghunlashturulmaq
		uyghunlashturulush
		uyghunlashturmaq
		uyghunlashti
		uyghunlashqan
		uyghunlashmaq
		uyghunliship
		uyghunlishish
		uyghunlishishqa
		uyghunlishishi
		uyghunluq
		uyghunmu
		======================================
		Izdeydighan qelip: z?w??
		zawal
		zawut
		zawén
		zewer
		zuwan
		======================================
		Izdeydighan qelip: a????mu
		ablizmu
		apisimu
		aptormu
		atashmu
		atangmu
		atisimu
		atlarmu
		achammu
		achtimu
		achsimu
		axirimu
		adashmu
		aditimu
		adimimu
		artismu
		artuqmu
		armanmu
		azabimu
		azraqmu
		asasimu
		asmanmu
		ashtimu
		asharmu
		ashiqmu
		ashsimu
		akisimu
		anangmu
		anisimu
		alaqimu
		altunmu
		almasmu
		almaymu
		alsaqmu
		alsammu
		amraqmu
		amilimu
		aminemu
		a’ilimu
		awazimu
		ayalimu
		aydinmu
		ayghimu
		======================================
		bugun ning namzatlirining sani : 10
		burun
		buzun
		bügün
		buyan
		buzup
		bulut
		boyun
		buyum
		bugha
		buzuq
		======================================
		keldiya ning namzatlirining sani : 11
		keldima
		keldiyu
		keldim
		kelding
		keldimu
		kelsila
		keldiki
		keldile
		kelduq
		köldin
		keldi

# UyghurSpell
Spellcheck module used in UyghurEditPP

This program based [Spell Checker Dictionary Engine](https://www.codeproject.com/Articles/4179/Spell-Checker-Dictionary-Engine)

# Diqqet:
   Sözlükni özingiz teyyar qilip ishliting. yeni "uyghur_imla.txt" ni özingiz teyyar qiling.

# Ishlitish usuli:

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

		//Barliq aqs din bashlanghan sozlerni izdep tapidu
		soz = "aqs*";
		List<string>  namzatlar = imla.GetSuggestions(soz);
		System.Diagnostics.Debug.WriteLine("bariq aqs bilen bashlanghan soz: " + soz);
		foreach(string nam in namzatlar){
			System.Diagnostics.Debug.WriteLine(nam);
		}
		System.Diagnostics.Debug.WriteLine("======================================");
		soz = "z?w??"; //birinchi herp z, 3-herp w bolghan 5 herplik sozni izdep tapidu
		System.Diagnostics.Debug.WriteLine("Birinchi herpi z, 3-herpi w bolghan 5 herplik soz: " + soz);
		namzatlar = imla.GetSuggestions(soz);
		foreach(string nam in namzatlar){
			System.Diagnostics.Debug.WriteLine(nam);
		}

		System.Diagnostics.Debug.WriteLine("======================================");
		soz = "a????mu"; // a bilen bashlanghan, axiri mu bilen axirlashqan 7 herplik sozni izdep tapidu
		System.Diagnostics.Debug.WriteLine("a bilen bashlanghan, axiri mu bilen axirlashqan 7 herplik soz: " + soz);
		namzatlar = imla.GetSuggestions(soz);
		foreach(string nam in namzatlar){
			System.Diagnostics.Debug.WriteLine(nam);
		}


		System.Diagnostics.Debug.WriteLine("======================================");
		soz = "d??e*"; // a bilen bashlanghan, axiri mu bilen axirlashqan 7 herplik sozni izdep tapidu
		System.Diagnostics.Debug.WriteLine("birnchi heripi d, 4-heripi e bolghan barliq sozler: " + soz);
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

# Netije:
		Uyghurche Imla Tekshrush Programisi we uni Ishlitish!
		Ekanda korushke qolay bolushi uchun Latinche halette sinaymiz
		Imla ambiridiki soz sani :145768
		Uyghur Imla ambirida Bar
		======================================
		bariq aqs bilen bashlanghan soz: aqs*
		aqsa
		aqsaray
		aqsarayni
		aqsarayning
		aqsaraygha
		aqsarayda
		aqsaraydin
		aqsaraydiki
		aqsarayliq
		aqsaq
		aqsaqal
		aqsaqalliq
		aqsaqalliri
		aqsaqallirini
		aqsaqallirining
		aqsaqalliridin
		aqsaqallirigha
		aqsaqallar
		aqsaqallarning
		aqsaqalni
		aqsaqalning
		aqsaqalgha
		aqsaqmaral
		aqsaqmaralliq
		aqsaqili
		aqsaqilini
		aqsaqilining
		aqsaq-cholaq
		aqsaqlash
		aqsaqliq
		aqsaqlimaq
		aqsaliq
		aqsay
		aqsap
		aqsam
		aqsatmaq
		aqsash
		aqsashmaq
		aqsitip
		aqsitish
		aqsitilmaq
		aqsitilish
		aqsil
		aqsilliq
		aqsillar
		aqsillarning
		aqsillarni
		aqsilni
		aqsilning
		aqsilgha
		aqsildin
		aqsili
		aqsilini
		aqsilining
		aqsimu
		aqsimaq
		aqsirash
		aqsirimaq
		aqsishish
		aqsöngek
		aqsöngekler
		aqsöngeklerning
		aqsöngeklerge
		aqsöngekliri
		aqsöngeklirining
		aqsöngeklirige
		aqsun
		aqsuni
		aqsuning
		aqsu
		aqsuluq
		aqsuluqlar
		aqsuluqlarning
		aqsularda
		aqsugha
		aqsughiche
		aqsuda
		aqsudimu
		aqsudin
		aqsudiki
		aqshebnem
		aqshil
		aqshimar
		aqshopa
		aqshopaliq
		aqsopi
		aqsopiliq
		======================================
		Birinchi herpi z, 3-herpi w bolghan 5 herplik soz: z?w??
		zawal
		zawut
		zawén
		zewer
		zuwan
		======================================
		a bilen bashlanghan, axiri mu bilen axirlashqan 7 herplik soz: a????mu
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
		birnchi heripi d, 4-heripi e bolghan barliq sozler: d??e*
		daden
		dadenlik
		dare
		darelik
		dane
		dane-dane
		danekche
		danen’gu
		danen’guluq
		derex
		derexzarliq
		derexzar
		derexsiman
		derexsiz
		derexlik
		derexliri
		derexlirini
		derexlirining
		derexliridin
		derexlirige
		derexler
		derexlermu
		derexlerning
		derexlerni
		derexlerge
		derexlerde
		derexlerdin
		derexlerdiki
		derexmu
		derexni
		derexning
		derexke
		derexte
		derextek
		derextin
		derextiki
		derextur
		deresh
		demeshq
		demeshqning
		demeshqte
		demeshqtiki
		demeshqlik
		dewet
		dewetchi
		dewetti
		dewettim
		dewetsingiz
		dewetken
		dewetke
		dewetmemsiz
		dewetni
		dewetning
		dewetname
		dewer
		dewerdim
		dewerse
		dewersek
		dewersun
		dewergin
		dewerme
		dewermeng
		dewermey
		deweldürük
		deweldürüklük
		dotey
		doteyning
		doteylik
		doden
		dodenleshtürmek
		dodenleshtürüsh
		dodenleshmek
		dodenlishish
		dodenlik
		dorem
		dore
		dönen
		dölet
		döletlik
		döletliri
		döletlirimu
		döletlirini
		döletlirining
		döletliriningmu
		döletliridin
		döletliridiki
		döletliridimu
		döletliride
		döletlirige
		döletla
		döletler
		döletlermu
		döletlerla
		döletlerning
		döletlerningmu
		döletlerningkidin
		döletlerni
		döletlernimu
		döletlerge
		döletlergimu
		döletlergiche
		döletlerde
		döletlerdimu
		döletlerdila
		döletlerdin
		döletlerdinmu
		döletlerdiki
		döletlerdur
		döletmen
		döletmenlik
		döletmu
		döletbagh
		döletbaghliq
		döletbay
		döletken
		döletke
		döletkimu
		döletkila
		döletni
		döletning
		döletningmu
		dölette
		dölettimu
		dölettin
		dölettiki
		dölettikiler
		dölettur
		döwe
		döwe-döwe
		düwet
		düwet-qelem
		dédek
		dédeklik
		dérek
		déreksiz
		déreklesh
		déreklimek
		dése
		dések
		désekla
		désekmu
		déseng
		désengla
		désenglar
		désengmu
		désem
		désemla
		désemmu
		désem-démisem
		démetlik
		démet
		démek
		démekte
		démektur
		démektin
		démekchi
		démekchidim
		démekchighu
		démekchiki
		démekchimen
		démekchimenki
		démekchimu
		démekchimizki
		démekke
		démeklik
		démekliktur
		déme
		démeptu
		démes
		démestin
		démeslik
		démeslikke
		démesliki
		démesmu
		démeng
		démenglar
		démemdu
		démemsen
		démemsiz
		démemsiler
		démey
		démeytti
		démeydu
		démeydighan
		démeydiken
		démeysen
		démeysiz
		démeyla
		démeyli
		démeymen
		démeymiz
		dégech
		dégechke
		dégen
		dégenti
		dégenting
		dégentim
		dégenche
		dégende
		dégendek
		dégendekla
		dégendekler
		dégendeklerge
		dégendeklerni
		dégendeklerning
		dégendu
		dégendiki
		dégendikidek
		dégendikin
		dégendila
		dégendimu
		dégendin
		dégen’ge
		dégen’ghu
		dégenken
		dégenler
		dégenlerde
		dégenlerdek
		dégenlerdin
		dégenlerge
		dégenlermu
		dégenlerni
		dégenlerning
		dégenlernimu
		dégenliri
		dégenlirige
		dégenliring
		dégenliringiz
		dégenlirini
		dégenlirining
		dégenlirim
		dégenlirimni
		dégenlirimning
		dégenlik
		dégenliktur
		dégenliktin
		dégenlikliri
		dégenlikmu
		dégenlikni
		dégenliki
		dégenlikige
		dégenlikim
		dégenlikini
		dégenmu
		dégenni
		dégenning
		dégennila
		dégennimu
		dégenidi
		dégenidim
		dégeniken
		dégey
		déyelemsiz
		déyeleydu
		déyeleydighan
		déyeleymen
		déyeleymenki
		déyeleymiz
		déyeleymizki
		déyelmey
		déyelmeytti
		déyelmeydu
		déyelmeydighan
		déyelmeydighanliqini
		déyelmeymen
		déyelmeymiz
		déyelmidi
		déyelmidim
		déyelmigen
		déyelidi
		déyelidim
		déyelisun
		déyeligen
		déyerlik
		déweng
		déwenglik
		déwenglikni
		déwenglikning
		déwenglishish
		déwengleshmek
		déweylep
		déweylesh
		déweyleshmek
		déweylishish
		déweylimek
		dipey
		dipeydek
		diger
		diwe
		diweng
		diwe-peri
		diwexi
		diwexiche
		diben
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

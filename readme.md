# Pitanje 1
Izvođenje programa je trajalo oko 5 sekundi (točnije 5.0043102 sekunde, izmjereno klasom Stopwatch).

# Pitanje 2
Program se izvodio na samo jednoj dretvi: glavnoj dretvi.

# Pitanje 3
Izvođenje programa je trajalo oko 1 sekunde (točnije 1.0339004 sekunde, izmjereno klasom Stopwatch).

# Pitanje 4
Svaka se izvodila na vlastitoj dretvi. Dakle 5 dretvi sveukupno za izvođenje ispisa A, B, C, D i E.

# Pitanje 5
Ako postoji više dretvi pokrenutih istovremeno koje mijenjaju jednu te istu varijablu, može doći do njihovog
međusobnog konflikta. S obzirom da se promjena varijable sastoji od više uzastopnih instrukcija, moguće je da
će dretva biti prekinuta negdje između tih instrukcija, i pokrenuti se druga dretva koja mijenja istu varijablu
te će dohvatom njene vrijednosti imati krivu vrijednost (jer ona prva dretva nije spremila svoje izmjene). Problem
se riješava metodom mutualne ekskluzije (dretva prije nego što uđe u kritički segment koda mora onemogućiti druge
dretve da uđu u njega dok god ona nije izašla). U današnjim višejezgrenim procesorima sa out-of-order izvođenjem
instrukcija se ovaj problem rješava na naprednije načine.

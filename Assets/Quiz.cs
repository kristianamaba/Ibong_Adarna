using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    static string[,,,] QAList =  {{{{"\"Pagkakita kay Don Juan ang matanda’y nanambitan sa malaking kaawaan ay madaling nilapitan\" Saan Kabanata magtatagpuan ang saknong ito?",null,null,null},{"Kabanata 6","Kabanata 9","Kabanata 7","Kabanata 8"}} ,
            {{"Sino ang anak ni Haring Salermo?",null,null,null},{"Donya Maria","Donya Leonora","Donya Valeriana","Donya Juana"}},
            {{"Sino ang asawa ni Don Fernando?",null,null,null},{"Donya Valeriana","Donya Leonora","Donya Maria","Donya Juana"}},
            {{"Si Leonora’y walang kibo\n" +
                    "Dugo niya’y kumukulo,\n" +
                    "Lason sa dibdib at puso\n" +
                    "Kay Don Pedrong panunuyo\n" +
                    "Anong uri ng tayutay ito?",null,null,null},{"Eksaherasyon","Panaramdam","Paguyam","Pagtutulad"}},
            {{"Ermitanyong tinanungan ni Don Juan upang makarating sa Reyno De Los Cristales. (Kabanata 19)",null,null,null},{"Unang Ermitanyo","Pangalawang Ermitanyo","Ikatlong Ermitanyo","Matanda"}},
            {{"Ang pangalawang anak ni Don Fernando at Donya Valeriana.",null,null,null},{"Don Diego","Don Pedro","Don Juan","Don Emilio"}},
            {{"Niyari sa kalooban\n" +
                    "Muwi na sa kanyang bayan,\n" +
                    "Puso niya’y malulumbay\n" +
                    "Sa malaong pagkawalay\n" +
                    "Anong uri ng tayutay ito?",null,null,null},{"Pagtatao","Pagwawangis","Pagpapalit-tawag","Pagtutulad"}},
            {{"Ano ang pamagat ng Kabanata 23?",null,null,null},{"Pagsubok sa binatang nagmamahal","Tigasan ng Talino","Malayang Umiibig","Ikakasal ka nga ba?"}},
            {{"Ano ang ibig sabihin ng balawis?",null,null,null},{"masamang tao","mabilis","naalis o nahiwalay","bigyan pansin"}},
            {{"Ilang araw ang naging pista?",null,null,null},{"Siyam","Pito","Sampu","Anim"}}},

            {{{"Saan iniwan ni Don Juan si Donya Maria?",null,null,null},{"Ibang bayan","Berbanya","Reyno De Los Cristales","Armenya"}} ,
                    {{"Sa ibaba ng ______ nakita ni Don Juan ang isang napakagandang ginintuang palasyo.",null,null,null},{"Balon","Kaharian","Bundok","Baybayin"}},
                    {{"Tawag sa taong may sakit?",null,null,null},{"Leproso","Ermitanyo","Serpyente","Higante"}},
                    {{"Dambuhala nagbabantay kay Donya Juana.",null,null,null},{"Higante","Serpyente","Agila","Ermitanyo"}},
                    {{"Isa tao na naninirahan sa bundok. Tumulong kay Don Juan upang hulihin ang Ibong Adarna.",null,null,null},{"Ermitanyo","Ikatlong Ermitanyo","Pangalawang Ermitanyo","Unang Ermitanyo"}},
                    {{"May malambing na tinig, hatinggabi kung dumating sa Piedras Platas na kanyang tirahan.",null,null,null},{"Ibong Adarna","Ermitanyo","Matanda","Wala sa Nabanggit"}},
                    {{"Bunsong anak ni Haring Fernando na labis niyang minamahal.",null,null,null},{"Don Juan","Don Diego","Don Pedro","Don Quixote"}},
                    {{"Panganay na anak na may tindig na pagkainam.",null,null,null},{"Don Pedro","Don Diego","Don Juan","Don Quixote"}},
                    {{"Unang inibig ni Don Juan.",null,null,null},{"Donya Juana","Donya Maria","Donya Leonora","Donya Valeriana"}},
                    {{"Kapatid ni Donya Juana na iniligtas ni Don Juan sa kamay ng serpyente.",null,null,null},{"Donya Leonora","Donya Maria","Donya Juana","Donya Valeriana"}}},

            {{{"Haring hinahangaan ng kanyang nasasakupan.",null,null,null},{"Haring Fernando","Haring Salermon","Don Juan","Don Pedro"}} ,
                    {{"Ilarawan ang tirahan ng Ibong Adarna.",null,null,null},{"Kumikinang ang mga dahon","Nakakalbo ang mga dahon","Kulay ginto ang ugat","Nakakasilaw ang mga sanga"}},
                    {{"Tawag sa punong tirahan ng Ibong Adarna.",null,null,null},{"Piedras Platas","Berbanya","Tabor","Reyno delos Cristales"}},
                    {{"Nabibilang ang Ibong Adarna sa tulang ____?",null,null,null},{"Romance","Ballad","Epiko","Tale"}},
                    {{"Ang Ibong Adarna ay akdang likha ni ___?",null,null,null},{"Wala sa na banggit","Andres Bonifacio","Jose Rizal","Francisco Balagtas"}},
                    {{"Isang balong pagkalalim\n" +
                    "Ang pinto ng bahay naming\n" +
                    "Pahugos na papasuki’t\n" +
                    "Sa itaas manggagaling\n" +
                    "Anong uri ng tayutay ito?",null,null,null},{"Metaphor","Personification","Hyperbole","Simile"}},
                    {{"Mahalama’t mabulaklak\n" +
                    "bango’y humahalimuyak\n" +
                    "may palasyong kumikislap\n" +
                    "na yari sa ginto’t pilak!\n" +
                    "Saan Kabanata matatagpuan ang saknong ito?",null,null,null},{"Kabanata 13","Kabanata 15","Kabanata 16","Kabanata 14"}},
                    {{"Ano ang nangyayari sa taong napapatakan ng dumi ng Ibong Adarna?",null,null,null},{"nagiging bato","nakakatulog","namamatay","naglalaho"}},
                    {{"Bakit nagkasakit si Haring Fernando?",null,null,null},{"Siya ay nanaginip","May epidemya sa kaharian","May lumason sa kanya","Siya ay isinumpa"}},
                    {{"Ano ang tawag sa kaharian na tahanan ng mga pangunahing tauhan?",null,null,null},{"Berbanya","Albanya","Atenas","Babilonya"}}},

            {{{"\"Sa payo nitong Adarna\n" +
                    "At Prinsipe’y lumakad na\n" +
                    "Nalimutan si Leonora’t\n" +
                    "Puso’y na kay Maria Blanca\"\n" +
                    "Saan Kabanata magtatagpuan ang saknong ito?",null,null,null},{"Kabanata 18","Kabanata 17","Kabanata 19","Kabanata 20"}} ,
                    {{"Ano ang ibinigay ng hari kay Don Juan bago ito maglakbay?",null,null,null},{"bendisyon","salapi","pagkain","kabayo"}},
                    {{"Ano ang ipinahiwatig ng mga prinsipe noong humarap sila sa panganib para sa ama?",null,null,null},{"Wagas ng pagmamahal nila sa kanilang magulang","Naghahangad sila ng malaking mana mula sa hari","Isang kahihiyan kung hindi sila kikilos para sa ama","Kayabangan nila sa angking lakas at kakisigan"}},
                    {{"Ano ang ginawa nina Don Pedro at Don Diego kay Don Juan para makuha ang ibon?",null,null,null},{"binugbog","itinali","nilunod","binitag"}},
                    {{"Ilang buwan ang ginugol ni Don Juan sa kanyang paglalakbay?",null,null,null},{"apat","tatlo","lima","anim"}},
                    {{"Ano ang nangyari pagkatapos gamutin ng matanda si Don Juan?",null,null,null},{"pinabalik niya ito sa Berbanya","dinala niya ito sa kanyang bahay","tinuruan niya ito na gumanti","binigyan niya ito ng agimat"}},
                    {{"Paano pinatunayan ni Don Juan  ang pagmamahal sa mga kapatid niya?",null,null,null},{"hiniling niya na patawarin ng hari ang mga kapatid","ipinauwi niya ang ibon kina Don Pedro at Don Diego","hindi nalang niya sinabi ang katotohanan sa hari","ibinigay niya ang ibon kina Don Pedro at Don Diego"}},
                    {{"Bakit hinatulan ng hari sina Don Pedro at Don Diego?",null,null,null},{"dahil sa lahat ng pagpipilian","dahil inangkin ng mga ito ang ibon","dahil pinagtulungan nila si Don Juan","dahil sinabi nila na hindi nila alam kung nasaan si Don Juan"}},
                    {{"Sa batisan yaong tubig,\n" +
                    "pakinggan mo’t umaawit,\n" +
                    "suso’t batong magkakapit\n" +
                    "may suyuang matatamis\n" +
                    "Ano uri ng tayutay ito?",null,null,null},{"Personification","Simile","Metaphor","Hyperbole"}},
                    {{"Sino ang Hari ng Reyno delos Cristales?",null,null,null},{"Haring Salermo","Haring Fernando","Haring Adolfo","Haring Florante"}}},

            {{{"Ang humatol na dapat ikasal si Don Juan at Donya Leonora.",null,null,null},{"Arsobispo","Haring Fernando","Haring Adolfo","Haring Florante"}} ,
                    {{"Ang Kapatid ni Donya Maria.",null,null,null},{"Donya Isabel","Donya Valeriana","Donya Leonora","Donya Juana"}},
                    {{"Alaga ni Donya Leonora na gumamot kay Don Juan sa Kaharian ng Armenya.",null,null,null},{"Lobo","Higante","Serpyente","Agila"}},
                    {{"Nagsabi na ang tanging lunas sa sakit ng hari ay ang awit ng Ibong Adarna.",null,null,null},{"Manggagamot","Ermitanyo","Matanda","Leproso"}},
                    {{"Ang nagturo ng daan at naghatid kay Don Juan patungong Reyno delos Cristales.",null,null,null},{"Agila","Lobo","Serpyente"," Higante"}},
                    {{"Tunay kaming magkapatid\n" +
                    "Ang matalo’y lubhang pangit\n" +
                    "Lalo pa nga’t sa pag-ibig\n" +
                    "Hindi dapat magkagalit\n" +
                    "Saan Kabanata magtatagpuan ang saknong ito?",null,null,null},{"Kabanata 28","Kabanata 27","Kabanata 26","Kabanata 29"}},
                    {{"Palamuti sa binata,\n" +
                    "ay napakagandang mutya;\n" +
                    "perlas, rubing tila luha\n" +
                    "ng langit sa abang lupa!\n" +
                    "Anong uri ng tayutay ito?",null,null,null},{"Simile","Metaphor","Personification","Hyperbole"}},
                    {{"Ilang kabanata mayroong ang Ibong Adarna?",null,null,null},{"46","36","26","56"}},
                    {{"Ano ang ibig sabihin ng Prasko?",null,null,null},{"bote","alam","palabas","plato"}},
                    {{"Babaeng tagapamahala ng isang imperyo.",null,null,null},{"Emperatris","Prinsesa","Reyna","Donya"}}},

            {{{"Ano ang ginawa in Don Juan sa tinapay?",null,null,null},{"Hindi niya Tinanggap","Tinapon","Ibinaon sa lupa","Tinanggap niya"}} ,
                    {{"Bago umalis si Don Juan, Bakit nalungkot siya?",null,null,null},{"Gustong ibalik ng matanda ang tinapay","Sinabi ng matanda na patay na ang kanyang dalawang kapatid","Namatay ang matanda","Sinabi ng matanda na patay na ang kanyang ama"}},
                    {{"Ayon sa matanda, bakit kailangang hanapin ni Don Juan ang dampa?",null,null,null},{"Ang nakatira doon ay magtuturo kung paano hulihin ang Ibong Adarna","Naroon ang Ibong Adarna","Doon siya dapat magpahinga","Naroon ang kanyang dalawang kapatid"}},
                    {{"Nang malaman ng matanda kung bakit naroon ang prinsepe, ano ang unang payo na binigay niya?",null,null,null},{"huwag huminto kapag nakita ang magandang puno kundi magpatuloy hangga't makita ang isang dampa","kumuha ng mga prutas at dalhin sa dampa","huminto sa magandang puno at doon matulog","kumain ng mga prutas sa magandang puno"}},
                    {{"Ano ang ginawa ng prinsepe nang makasalubong niya ang matandang leproso?",null,null,null},{"binigay niya ang isang natitirang tinapay","binigyan niya ng ginto","pinainom niya ng tubig","pinatay niya"}},
                    {{"Sino ang nakasalubong ni Don Juan sa kanyang paglalakbay?",null,null,null},{"Matandang leproso","Don Diego","Don Pedro","Ibong Adarna"}},
                    {{"Habang naglalakbay si Don Juan, kanino siya tumawag ng tulong?",null,null,null},{"Mahal na Birhen","Sa Engkanto","Sa Ina","Ibong Adarna"}},
                    {{"Gaano katagal bago niya narating ang tuktok ng bundok?",null,null,null},{"apat na buwan","isang buwan","Anim na buwan","tatlong buwan"}},
                    {{"Paano siya naglakbay?",null,null,null},{"naglakad","lumipad","nagkabayo","nakasakay sa kamelyo"}},
                    {{"Ano ang dala ni Don Juan sa kanyang paglalakbay?",null,null,null},{"limang piraso ng tinapay","sampung prasko ng alak","mahiwagang kumot","tatlong kabayo"}}},

            {{{"Nang hindi pinayagan si Don Juan ni Haring Fernando na pumunta sa bundok Tabor, ano ang sinabi niya sa kanyang ama?",null,null,null},{"tatakas siya","magpapakamatay siya","magkukulong siya","susunugin niya ang palasyo"}} ,
                    {{"Ilang taon ang lumipas bago nagdesisyon si Don Juan na hanapin din ang Ibong Adarna?",null,null,null},{"tatlong taon","isang taon","limang taon","dalawang taon"}},
                    {{"Pagkatapos ang ika-pitong awit ng ibon, ano ang nangyari kay Don Diego?",null,null,null},{"naduhiman at naging bato","nakaligtas sa dumi","namatay","naparalisado"}},
                    {{"Ano ang nangyari kay Don Diego nang makita niya ang Ibong Adarna?",null,null,null},{"lahat na nakasulat dito","nakinig sa awit","nakatulog","namangha"}},
                    {{"Ano ang pinagtatakahan niya nang makita niya ang nagkikintabang mga dahon at sanga ng Piedras Platas?",null,null,null},{"walang dumadapo na ibon","nagliliyab ang dahon","anim na kuwago ang nakabantay sa puno","may sarili itong bahaghari"}},
                    {{"Gaano katagal ang paglalakbay ni Don Diego patungong Bundok Tabor?",null,null,null},{"limang buwan","walong taon","isang taon","anim na buwan"}},
                    {{"Sino ang pangalawang nagtangkang humuli sa ibon?",null,null,null},{"Don Diego","Don Juan","Don Pascal","Don Salermo"}},
                    {{"Habang nag lalakbay si Don Juan, kanino siya humingi ng tulong?",null,null,null},{"Mahal na Birhen","sa ina","sa engkanto","Ibong Adarna"}},
                    {{"Sino ang nakasalubong ni Don Juan sa kanyang paglalakbay?",null,null,null},{"Matandang Leproso","Don Pedro","Don Diego","Ibong Adarna"}},
                    {{"Ano ang ginawa ng Prinsepe nang makasalubong niya ang Matandang Leproso?",null,null,null},{"binigay niya ang isang natitirang tinapay","binigyan niya ng ginto","pinainom niya ng tubig","pinatay niya"}}},

            {{{"Nang malaman ng matanda kung bakit naroon ang Prinsepe, ano ang unang payo na binigay niya?",null,null,null},{"huwag huminto kapag nakita ang magandang puno kundi mag patuloy hanggat makita ang dampa","kumuha ng prutas at dalhin sa dampa","huminto sa magandang puno at doon matulog","kumain ng mga prutas saa magandang puno"}} ,
                    {{"Ayon sa matanda bakit kailangang hanapin ni Don Juan ang dampa?",null,null,null},{"ang nakatira doon ang magtuturo kung paano hulihin ang Ibong Adarna","naroon ang Ibong Adarna","doon dapat siya mag pahinga","naroon ang kanyang dalawang kapatid"}},
                    {{"Bakit malungkot si Don Juan noong umalis siya?",null,null,null},{"gustong ibalik ng matanda ang tinapay","sinabi ng matanda na patay na ang kanyang dalawang kapatid","namatay ang matanda","sinabi ng matanda na patay na ang kanyang ama"}},
                    {{"Ano ang ginawa ni Don Juan sa tinapay?",null,null,null},{"hindi niya tinanggap","tinapon","ibinaon sa lupa","tinanggap niya"}},
                    {{"Ang kwento na Ibong Adarna ay isang ____.",null,null,null},{"korido","alamat","epiko","nobela"}},
                    {{"Ano ang korido?",null,null,null},{"tula sa pag-ibig","kwento ng kabayanihan","nobela tungkol sa kasaysayan","alamat ng hayop"}},
                    {{"Si Jose Dela Cruz ay kilala bilang __?",null,null,null},{"Huseng sisiw","Huseng Batute","Agapito Bagumbayan","Siling Labuyo"}},
                    {{"Sino ang unang naglakbay patungong Mt. Tabor para hulihin ang ibon?",null,null,null},{"Don Pedro","Don Juan","Don Diego","Don Pascal"}},
                    {{"Gaano katagal naglakbay si Don Pedro?",null,null,null},{"tatlong buwan","isaang taon","isang buwan","limang buwan"}},
                    {{"Paano nalaman ni Don Pedro na nakita na niya ang Piedras Platas?",null,null,null},{"naririnig niya ang awit ng ibon","Ibat ibang prutas ang bunga nito","ibat ibang kulay ang dahon","kumikislap ang mga dahon ‘pag naa"}}},

            {{{"Bakit hindi niya nahuli ang ibon?",null,null,null},{"nakatulog siya","hindi niya makita dahil nasisilaw siya sa kislap ng mga dahon","mabilis na nakakatakas ang ibon","naparalisado ang kanyang katawan"}} ,
                    {{"Anong nangyari kay Don Pedro nang maiputan siya ng ibon?",null,null,null},{"naging bato","namaho","nangati","naparalisado"}},
                    {{"Ilang taludtod mayroon ang Ibong Adarna?",null,null,null},{"4","8","5","6"}},
                    {{"Ilang pantig bawat taludtod?",null,null,null},{"8","9","10","6"}},
                    {{"Ilang beses umawit ang ibon?",null,null,null},{"pito","anim","lima","tatlo"}},
                    {{"Ano ang nangyayari sa ibon pagkatapos ng bawat awit?",null,null,null},{"naiiba ng kulay o anyo ng balahibo","kumakain","natutulog","dumudumi"}},
                    {{"Ano ang ginagawa ng ibon pagkatapos umawit ng pitong beses?",null,null,null},{"dudumi","lilipad","kakain","matutulog"}},
                    {{"Isang balong pagkalalim\n" +
                    "Ang pinto ng bahay naming\n" +
                    "Pahugos na papasuki’t\n" +
                    "Sa itaas manggagaling\n" +
                    "Anong uri ng tayutay ito?",null,null,null},{"Metaphor","Personification","Hyperbole","Simile"}},
                    {{"Mahalama’t mabulaklak\n" +
                    "bango’y humahalimuyak\n" +
                    "may palasyong kumikislap\n" +
                    "na yari sa ginto’t pilak!\n" +
                    "Saan Kabanata matatagpuan ang saknong ito?",null,null,null},{"Kabanata 13","Kabanata 15","Kabanata 16","Kabanata 14"}},
                    {{"Sa paglalakbay niya, ano ang nangyari sa kanyang kabayo?",null,null,null},{"namatay","biglang nakapagsalita","napilayan","nagkasakit"}}},

            {{{"Bakit nagkasakit si Haring Fernando?",null,null,null},{"Siya ay nanaginip","May epidemya sa kaharian","May lumason sa kanya","Siya ay isinumpa"}} ,
                    {{"Ano ang tawag sa kaharian na tahanan ng mga pangunahing tauhan?",null,null,null},{"Berbanya","Albanya","Atenas","Babilonya"}},
                    {{"\"Sa payo nitong Adarna\n" +
                    "At Prinsipe’y lumakad na\n" +
                    "Nalimutan si Leonora’t\n" +
                    "Puso’y na kay Maria Blanca\"\n" +
                    "Saan Kabanata magtatagpuan ang saknong ito?",null,null,null},{"Kabanata 18","Kabanata 17","Kabanata 19","Kabanata 20"}},
                    {{"Ano ang ibinigay ng hari kay Don Juan bago ito maglakbay?",null,null,null},{"bendisyon","salapi","pagkain","kabayo"}},
                    {{"Ano ang ipinahiwatig ng mga prinsipe noong humarap sila sa panganib para sa ama?",null,null,null},{"Wagas ng pagmamahal nila sa kanilang magulang","Naghahangad sila ng malaking mana mula sa hari","Isang kahihiyan kung hindi sila kikilos para sa ama","Kayabangan nila sa angking lakas at kakisigan"}},
                    {{"Ano ang ginawa nina Don Pedro at Don Diego kay Don Juan para makuha ang ibon?",null,null,null},{"binugbog","itinali","nilunod","binitag"}},
                    {{"Ilang buwan ang ginugol ni Don Juan sa kanyang paglalakbay?",null,null,null},{"apat","tatlo","lima","anim"}},
                    {{"Ano ang nangyari pagkatapos gamutin ng matanda si Don Juan?",null,null,null},{"pinabalik niya ito sa Berbanya","tinuruan niya ito na gumanti ","dinala niya ito sa kanyang bahay","binigyan niya ito ng agimat"}},
                    {{"Paano pinatunayan ni Don Juan  ang pagmamahal sa mga kapatid niya?",null,null,null},{"hiniling niya na patawarin ng hari ang mga kapatid","ipinauwi niya ang ibon kina Don Pedro at Don Diego","Wala sa nabanggit","hindi nalang niya sinabi ang katotohanan sa hari"}},
                    {{"Ano ang nangyayari sa taong napapatakan ng dumi ng Ibong Adarna?",null,null,null},{"nagiging bato","nakakatulog","namamatay","naglalaho"}}}};

    static List<int> queue = new List<int>();
    static int n = 1, score = 0, cIndex, lvl = 1;
    static System.Random rand = new System.Random();
    static long cTime = 5020;
    bool answered = false,roundFin = false;
    public TextMeshProUGUI a1, a2, a3, a4;

    public AudioSource correctS, wrongS;

    


//public Text question, timerT, scoreT, over; // messageF, result, round;
static Timer waitTimer;


    public void a1Pressed()
    {
        ansPress(a1.text);
    }
    public void a2Pressed()
    {
        ansPress(a2.text);
    }
    public void a3Pressed()
    {
        ansPress(a3.text);
    }
    public void a4Pressed()
    {
        ansPress(a4.text);
    }

    public void returnToMap()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void setTUI(String name, String v)
    {
        GameObject.Find(name).GetComponent<TMPro.TextMeshProUGUI>().text = v;
    }
    void Start()
    {
        lvl = PlayerPrefs.GetInt("currentlevel", 1);
        beginlvl(lvl);
    }
    public static void fpanelED(bool b) {
        GameObject.Find("fpanel").gameObject.transform.localScale = (b == true ? new Vector3(1, 1, 1) : new Vector3(0, 0, 0)); 
    }
    void Update()
    {
        setTUI("TimerUI", (cTime <= 0 ? "GAME OVER" : ((double)cTime / 1000).ToString("0.00"))); //TIMER COUNT
        if (cTime <= 20 && roundFin == false && score < 10)
        {
            finish("TIME'S UP", "FAILED!", "Times's up, you failed", false); //ON FINISH
            roundFin = true;
        }
           
        
    }
    public void beginlvl(int l)
    {
        setTUI("Stage", (lvl <= 4 ? "Easy round" : (lvl <= 7 ? "Average round" : "Difficult round")));
        restart();
    }
    public static void finish(string mesT, string resT, string toastT, bool win)
    {
        shutDownTimer();
        fpanelED(true);
        setTUI("fmes", mesT);
        setTUI("fscore", "Score: " + score + " / 10" );
        p(toastT);
        setTUI("trynext", (win == true ? (lvl>=10 ? "Start Menu" : "Next level") : "Try Again"));

        if (win && PlayerPrefs.GetInt("level", 1) <= 1 + lvl)
            PlayerPrefs.SetInt("level", 1 + lvl);

        
    }


    //Restart quiz every thing
    public void restart()
    {
        fpanelED(false);
        roundFin = false;
        n = 1;
        score = 0;
        cTime = 10000;
        countDownStart();
        randQues(lvl - 1);
        reset();
    }

    public static void shutDownTimer()
    {
        if (waitTimer != null)
            waitTimer.Dispose();
    }

    public static void countDownStart()
    {
        waitTimer = new Timer(TimerCB, null, 0, 20);
    }

    

    private static void TimerCB(object o)
    {
        cTime -= 20; 
    }



    public void trynext()
    {
        shutDownTimer();
        String s = GameObject.Find("trynext").GetComponent<TMPro.TextMeshProUGUI>().text;
        if (s == "Next level" || s == "Start Menu")
        {
            if (lvl >= 10)
                SceneManager.LoadScene("Start");
            else
            {
                
                
                beginlvl(1 + lvl++);
            }
        }
        else {
            fpanelED(false);
            restart();
        }
    }

    //Answer Button pressed
    public void ansPress(String answer)
    {
        try
        {
            if (answered == false)
            {
                answered = true;

                if (QAList[lvl - 1, cIndex, 1, 0] == answer)
                { // Correct
                    showToast("Correct ! + 2 seconds",1);
                    cTime += 2000;
                    ++score;
                    if (PlayerPrefs.GetInt("BGM", 1) == 1)
                        correctS.Play();
                }
                else
                { //Wrong
                    showToast("Wrong ! - 1 seconds", 1);
                    queue.Add(cIndex);
                    cTime -= 1000;
                    if(PlayerPrefs.GetInt("BGM", 1) == 1)
                        wrongS.Play();
                }

                if (score >= 10)
                {
                    finish("FINISHED", "SUCCESS!", "Times's up, you win!", true);
                }
                else if (waitTimer != null)
                {
                    reset();
                }
            }
        }
        catch (Exception e)
        {
            p(e.ToString());
        }
    }

    public Text txt;



    void showToast(string text, int duration)
    {
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = txt.color;

        txt.text = text;
        txt.enabled = true;

        //Fade in
        yield return fadeInAndOut(txt, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txt, false, 0.5f);

        txt.enabled = false;
        txt.color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }







    //Reset buttons/question
    public void reset()
    {
        answered = false;

        if (n <= 10)
        {
            setQA(n - 1);
        }
        else if (score < 10 && queue.Count > 0)
        {
            setQA(queue[0]);
            queue.RemoveAt(0);
        }
    }

    //Assign Button and Question text
    public void setQA(int index)
    {
        cIndex = index;
        setTUI("Question", QAList[lvl - 1, index, 0, 0]);
        string[] randA = randAns(QAList[lvl - 1, cIndex, 1, 0], QAList[lvl - 1, cIndex, 1, 1], QAList[lvl - 1, cIndex, 1, 2], QAList[lvl - 1, cIndex, 1, 3]);
        a1.text = randA[0];
        a2.text = randA[1];
        a3.text = randA[2];
        a4.text = randA[3];
        //OVER TEXT
        setTUI("Level", (n > 10 ? (queue[0] + 1) : n) + "/10");
        ++n;
    }



    public static void p(string s)
    {
        Debug.Log(s);
    }


    //Randomize Questions
    public static void randQues(int n)
    {
        for (int i = 0; i < 10; i++)
        {
            int r = rand.Next(10);

            string tempQ = QAList[n, r, 0, 0], at1 = QAList[n, r, 1, 0], at2 = QAList[n, r, 1, 1], at3 = QAList[n, r, 1, 2], at4 = QAList[n, r, 1, 3];
            QAList[n, r, 0, 0] = QAList[n, i, 0, 0];
            QAList[n, r, 1, 0] = QAList[n, i, 1, 0];
            QAList[n, r, 1, 1] = QAList[n, i, 1, 1];
            QAList[n, r, 1, 2] = QAList[n, i, 1, 2];
            QAList[n, r, 1, 3] = QAList[n, i, 1, 3];

            QAList[n, i, 0, 0] = tempQ;
            QAList[n, i, 1, 0] = at1;
            QAList[n, i, 1, 1] = at2;
            QAList[n, i, 1, 2] = at3;
            QAList[n, i, 1, 3] = at4;

        }
    }

    //Randomize Answers
    public string[] randAns(string a1, string a2, string a3, string a4)
    {
        string[] QAT = { a1, a2, a3, a4 }; ;
        for (int i = 0; i < 4; i++)
        {
            int r = rand.Next(4);
            string temp = QAT[r];
            QAT[r] = QAT[i];
            QAT[i] = temp;
        }
        return QAT;
    }

}




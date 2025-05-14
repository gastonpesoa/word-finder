namespace QuDeveloperChallenge.Library.Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Constructor_ShouldNotAssigNullToMatrixProp()
        {
            // Act
            WordFinderBruteForce wordFinder = new(null);

            // Assert
            Assert.Empty(wordFinder.Matrix);
        }

        [Fact]
        public void Constructor_MatrixShouldNotExceed64Columns()
        {
            // Arrenge
            string[] matrix = [
                "mvtsopdsowuewmfvspeachitqkuvshqgkshrdczdhajepkedunqgfdhlaytkjrxqwe",
                "yzxzeywktpearqvpeefhqowmruigynhjqzmivpxlycjjuqvzyhjgynczwbpxnhaert",
                "axnfigkbnmqhdxkdxiksvdxyrxyegpguavajcvkiqdormjvqynqkcsttqhnwvivdfg"];

            // Act
            WordFinderBruteForce wordFinder = new(matrix);

            // Assert
            Assert.Empty(wordFinder.Matrix);
        }
        
        [Fact]
        public void Constructor_MatrixShouldNotExceed64Rows()
        {
            // Arrange
            string[] matrix = [
                "jrx","nha","viv","qxf","ohb","fss","jrr","ccr","bly","jnt","idk","fre",
                "lvs","ksm","vaz","dna","bcr","acp","efw","jgv","ctx","qdd","uum","tqi",
                "sju","mfu","cwm","lbg","yie","vjf","vln","okv","ovh","mek","ald","pkx",
                "poh","lpz","eha","tnf","eun","zkt","xtw","fdf","gfz","sac","ppc","dpa",
                "cjd","qka","vpo","oue","gbp","hob","njs","tdn","byo","syx","ckx","yaw",
                "cju","cju","cju","cju","yie","vjf","vln","okv","ovh","mek","ald","yaw"
            ];

            // Act
            WordFinderBruteForce wordFinder = new(matrix);

            // Assert
            Assert.Empty(wordFinder.Matrix);
        }
        
        [Fact]
        public void Constructor_AllRowsShouldContainTheSameNumberOfCharacters()
        {
            // Arrange
            string[] matrix = ["jrx", "nhasdfsdf", "vivas", "qxfasdasdaiusfhiua"];

            // Act
            WordFinderBruteForce wordFinder = new(matrix);

            // Assert
            Assert.Empty(wordFinder.Matrix);
        }

        [Fact]
        public void Find_ShoulReturnCollectionOfStrings()
        {
            // Arrange
            string[] matrix = [];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] wordstream = [];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);
            
            // Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(actual);
        }

        [Fact]
        public void Find_ShoulReturnEmtySetOfStringsIfNoWordsAreFound()
        {
            // Arrange
            string[] matrix = ["djeeomrk"];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] wordstream = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Find_ShoulReturnWordFoundInAMatrixRowContainingIt()
        {
            // Arrange
            string[] matrix = ["abccoldwec"];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] expected = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnWordsFoundInARowContainingThem()
        {
            // Arrange
            string[] matrix = ["abccoldwerefvchillpoic"];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] expected = ["cold", "chill"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnWordFoundInAMatrixColumnContainingIt()
        {
            // Arrange
            string[] matrix = ["a", "b", "c", "c", "o", "l", "d", "w", "e", "r"];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] expected = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnEmtySetOfStringsIfNoWordsAreFoundInColumn()
        {
            // Arrange
            string[] matrix = ["a", "b", "c", "f", "t", "n", "d", "w", "e", "r"];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] wordstream = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Find_ShoulReturnWordsFoundInAMatrixContainingThem()
        {
            // Arrange
            string[] matrix = [
                "abcwec", 
                "mwindx", 
                "jcosac", 
                "zoknro", 
                "ilfehn", 
                "edctyj"
            ];
            WordFinderBruteForce wordFinder = new(matrix);
            string[] expected = ["cold", "wind"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulContainWordFoundInALargeMatrixContainingThem()
        {
            // Arrange
            string[] matrix =
            [
                "mvtsopdsowuewmfvspeachitqkuvshqgkshrdczdhajepkedunqgfdhlaytkjrx",
                "yzxzeywktpearqvpeefhqowmruigynhjqzmivpxlycjjuqvzyhjgynczwbpxnha",
                "axnfigkbnmqhdxkdxiksvdxyrxyegpguavajcvkiqdormjvqynqkcsttqhnwviv",
                "plemhuufhxyrffkblplumonukwmghmwalvyuetlwlyumxqhdzbftlhvkaryyqxf",
                "plipvxhxhjfgzlxrfkmqoaxodbcvyhqqomtkglimexozhjamgpnuwtybyhoyohb",
                "emzgrapeugkcjxdqzkqceosjqpywqzjfoxndymxgwicglwruiupxuxjmwmncfss",
                "hnqkuijgdzsbczfkgvnnnlvbnurkeqsigoxjdcmibzuuedmhqmgdfgaqajvkjrr",
                "ananagvwtkwshxcozjxqpmvjyoamvyuyrhdkupldtljftcqlemonnbfbaxzmccr",
                "nbananatlmrnzsbpxheukzihzmtfrxoyjzpyclbmkmqcvpmukiknltxkqwzkbly",
                "abkdaoscppkhlpcheknqenqdvllwacjbghmewydgcsvosdihzcalqzmrjkdujnt",
                "nqfkkwdbnxppqwulmdfcahoxsoenpnycoconutnzkemzbqmioklfhzwsjtfnidk",
                "awgyxziwgjbxcrgkbscpbujebnjydxemngfbdshcdkflmwoykncegxobcruyfre",
                "mkwiikwwanxyosnapmndpttqbnemamljytwrdukhpzhsfpohzdorznnvnbqdlvs",
                "gkjhcsdwcyczmangoqcbjxzhwqijefcypqwacqeqxjkikiyxiztbujegldnfksm",
                "ozfgspdxosqehvfigdkpkglkzsnxdgbnqbnvmbueboivhnyscqgddntvabmevaz",
                "rfzppixqwkjuevxkikhsxyuvnwjztdafnprxvcofrpbdgdgppzjqsvvylzgvdna",
                "xkbgmjkdvfigkqpbkqjbxkkkshbrxyxjjdszvcrhhgvvwkwkgkbnqswlzdkzbcr",
                "bjdswqqkzqxfduqtdzlmvodvqrxdfkjwluqomvaylxjppcqqhjvzbgpapayaacp",
                "atfdtikaxegshlfdmuqzhvjjzbyjsklsrwxxyvzavfigmgmhzddmuwkghftgefw",
                "nmmccjngddcqxhccwbnfyynionzptvrhlwxelwyepnfbjpqktyekeyjnyktfjgv",
                "eqxukiyrpjksdtdqqkfwtgkdtbkcbbmtrixpbjxyjjgeapricotsunlnvnotctx",
                "wtwfjkzqgpffohguedebixwlozjzdfqccxkzswjqoqdyfqwefufjijmvqekpqdd",
                "rxblhvqdgkguvvhxhvfpiwbdzrgclzhjvwwmnkktdjsxrkqcherryxpcldqruum",
                "ukcrusmtwvhvrsnlkzbyjaavunptfxtayxkrrcmfwmqgiinddhpjaxuyvnsltqi",
                "vcrtehvyhbfevbyxapdmbtfayzqyohrzkopkxarwvlhpdatelxcwjacgxdpqsju",
                "xnfcfpqwxvjkvhxornhbwdbtcrqxyjsvqxykxkzxlyoucnjsikprwlkxnptnmfu",
                "eizqubexwtkbqjyxyzxzuyrvgguuwpwxvxqegbohvwniifxaqhubqmwyouftcwm",
                "dekwxwpbmvgwbbyweivvlrzczqckbrnsnkyypapfrtflaytmdeghyxlhxflrlbg",
                "blwhtrzqrxxnzebqhqhfrczjbkveorpxnorrwoxwiwfkfbzqpemhfqncjupuyie",
                "bbhggjeipbydmmjoolrxzceokmtfjrslwcksjzcnjqynacswvvxehknsiydfvjf",
                "icfigemeflqfrhqcwfgkplcqzzwdfmywluaztjsnzmeibpwaqdrkfbbpmgpdvln",
                "wyzmmgaftuqnmgwganvrfwtfjzqrnfkphrrfhnvqpctgsxgwevcvphajlnanokv",
                "kkprmefyfdcwqeqbbhsqwqjjomxrcwdixyqggmlnsmvjehoayjscmjscqjzpovh",
                "ijqseulkrbkquaeipcdsgpcwtfubmoaqjwnenkeulcytrympgfdplowfxxpimek",
                "xzwqapczlhpsyyhzsntnqhklcfpjmmqglfwshqsnmpkcicbdfvxkphqimzuwald",
                "fvoxxxyxgudgyuqiwfaudbcxypnmzrhnnevgymkgldijjcvxdlnioajtoeyjpkx",
                "njszgfkfjjzfpjnhhxhserenfwzooiqknjcjxwjzkfbxcnakmlimehpngqgspoh",
                "pvqzncpxzwmrpmcfshuiipfzvrytcftpmloihxldmfugmcjqdqlrjppbyshnlpz",
                "ixzovowtxybgyvwrdpgbigvhpnlnldzazzbmokmbukpvvcpqxwugqqvhqhddeha",
                "qbcgtiybcdujciyusupjoaxvxgoeyggzswzkpoynklzksppquxxieivkltxptnf",
                "aeybcpiqtwaeqwyjkqfquqvcbqnvmkqwmxrdzdkexohqnbpdlpdvckumnxyoeun",
                "dlymyhczuqksyvzqylckvfrwwsznysfcwmibpgouykwnpmreghrnlzjoqmjpzkt",
                "qkrnnqwznbfddfapmdimdbvjozzepkmtzbgwhwokmdvuulihylztcnhfybcyxtw",
                "slrzvhedlnxdgxexuymmpuqtqceqlvfqehkiwpwhqgqwsomuvyrzlabttrshfdf",
                "zhbykjrwccwfsndkfaqrynbmyrthibekduddugweqbyplveceoxlatbwqcfygfz",
                "yofeckbpvzeogzqjyzkxwigmfbbqwcaopbeoxnltcehtrpmebgshixsnpmzxsac",
                "mhhtndilwdmwuonadphmlwwtmdhquvtakzqrkpfrzhnhqzexmksipfaqgrkrppc",
                "voblrznxwckfuqgxnzlenbpmrxzibdnmbeafrlvcppjdhqaerxgxwmowzfyydpa",
                "bvjrjeijdrkuxtlqzyayygexfhllaqwbffueqlwsrffvkxwevucwzkktzzlvcjd",
                "zuvshnvsdzyvszjvftyiwybatotsunvlwvcegjazvlpmmdfwbbeyuykpfxwzqka",
                "faavdkuwzujmuqgmmkkckuwhlbtkrsqcsidxafutmvshqpwogmztwlcvhgffvpo",
                "cvnzsycyhwlbphsudquhktfdpjrzzwdcylrpnnslgmmqxdrkgcjsojstkaasoue",
                "mjfggnktzrrbiomfrgqothbzrkbijasfrahmadysclqonbxmakmpewzqmmolgbp",
                "zmlwobxssxjytdxlwqbtpjhkocvqjcfdzqeuryanxxubxltwhnbcnutjnjcqhob",
                "xuwmcuagwlbqpnzpgwrntveijuyqijwrgigmtzscoszmlmxlzuvtkxpxmluanjs",
                "dcklaegwjxjgxblqpqycdzcjaivktotzvhkcxzzqjqojqkpmbypiooqltbdmtdn",
                "bbgwrurwdlfkqulohwjfcjemuhdzmtkzuxclsdteyehykqxmqwfqqzmdtazobyo",
                "vubkjxnzzzgmyuaifhhwqdfywwutlmqgnsikjsqyaqgjsguxkdeflagydpnjsyx",
                "hhfqtnxiwkmkebbhcufcbqdocjfyeqxpuuwbawewnrmtoxodrrvukgjypsaeckx",
                "nlvbbnfgpapayaodkllozlmazbnyasahvnpgznddkguyzqhhoynuxtxlpapayaw",
                "dfwmdchmzeekawxrsviukznwgjbdbvrimfhmgaydkheacwxyzoqtbnvqsrmecju"
            ];

            WordFinderBruteForce wordFinder = new(matrix);
            string[] wordstream =
            [
                "banana", "apple", "orange", "grape", "lemon", "melon", "peach", "berry", "mango", "guava",
                "plum", "kiwi", "lime", "fig", "date", "pear", "apricot", "cherry", "papaya", "coconut",
            ];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);

            // Assert
            Assert.NotEmpty(actual);
            Assert.Contains("banana", actual);
            Assert.Contains("apple", actual);
            Assert.Contains("papaya", actual);
        }

        [Fact]
        public void Find_ShouldReturnTheTopTenMostRepeatedWordsFromTheWordstreamFoundInTheMatrix()
        {
            // Arrange
            string[] matrix =
            [
                "chgpvochmwypvksurewoeyxrvgxmfaHARVESTqmumawmqbpnowomeodapwfsvfyv",
                "fxmgygdhrqrggvvdzrgkgodiuvmtyslcxwuqppuqrvbsxrojhjbeepdfsjdicmtn",
                "xkwpbiqGOLDENkedybrlafGOLDENpskhimltfpohabokygxnjgzvpvmddfmcresw",
                "cwhjwuwwklfeoqulsezFLORALomcwbwxzxkgqwHARVESTqiehigsxqpsbxxvwGvx",
                "agdhxlombaifududwbilfdlsapbfmsalohgerclajtSUNSHINEihofsmxtaihOir",
                "nlcoilexhfdwbgypqcBEACHflogvaGLACIERytbesooyuaoqmijimasvewhvsLjg",
                "GnjjvghymjwzivecHUMIDrrzfcqnjpqurdoxunhottckyltgzthjjptgnyiqxDpy",
                "OazfinpeswzwkcyvodgdyktjeeenqkieLEAVESwvlfukweitjjnmkyvkwykouEyu",
                "LtjjvcferfpfqryketekmvqBEACHsigrjvabmdzpwzsbpfmazyrcpzgjjeumrNuj",
                "Dwnmvglmeztamccbqdhljcrlwmnamndcwkqouajgopffxrdtonwlzolrdckxlgsb",
                "EqnzafobabudzhowgsnqowbmnFLORALcyykaptdhdachnivgizgscjttifmduhnc",
                "NqgemijsuauyiqjvzryrcqkHARVESTnksjmfxgkulffzqpimofdoaiyeykcqavxk",
                "aqhwvkpizanuiobnsmdhoztrnkecqdizafzoqrhaugkobkfuuuqanjcmixxmpcia",
                "HdhfyfkphysqvnwaqfugjBLIZZARDhyygousutmGOLDENuahjqxrxwopjsxxousk",
                "Upnhabnvjpevzclcyyiortbuyhewqmqvjvlruigjmbqdpmkofizczcbnomnuixkp",
                "MykmiegmcajvnsxgfkvdazaxycirkdyLEAVEShcweeyxztyjfqzlttcqjyzevrfn",
                "Iavgpiumakllkoozvbluextxkyqzaojhfveduhmmpglbcnbwihszlpszjfnnsnlu",
                "DdxohbchrlnvjHARVESTqmlyzbheqxamuzjuklykjsytqtxonrjotwcklgkgjett",
                "safiswckeoiktxhpmzllvvnfmszxrkuqrlmcsordjjsdajilkxkoijjxmgvdbuqm",
                "cefjqldmpwkoudjmBEACHsitxxoossjwgzcpvzpvexlpcaakzqhudGOLDENwwovo",
                "bztlzbfvzvpkyzcuvyzqttHARVESThkobxnqrzqzdxptdegqywhwtrpzwxszzygk",
                "qdmfnvhfwfbpqqnmqdznquwrcglrydxuoptpmqFREEZExamavwvjdqtrbphndhxk",
                "wlmdybzrlxgzdzgocxwyfuzsrneljiqhjenodwveqeeanmmarrfjfhrejxialuns",
                "sbypjirkcatumorfezemzttnfxlmflaumqqjqoHUMIDrhupssjaqsvwlspidpwhw",
                "enhmnvzpdnogfxcnbrjeebzqomdnkxlfxirpccnwhvzawifbjtoaqoiqvvubdncz",
                "dqggcpuesvekzbmvkbquzsaxwgogknbudxuqryGOLDENxfcazzkhrzyipfpeqvet",
                "dpxwfnnayzhrtkeikmcihdtlhwmnruiiuqflSNOWdmxsqrhqshjgnyjpjvxqbtif",
                "cdtczyyugjjtzfgowhpmjewqmnwebkiucuzwrddvhffsjbcsbpepltmuaxmmaaxt",
                "zblsqzaxccodrnytzntobopcdanSUNSHINEdqygrsgnmwnvhbldleyndahwtiurk",
                "oyvhxidrjeoinfknbbzcuxjnHUMIDmrxtCHILLpcfocmektrstpttgcqqvoqsmdn",
                "gjmswvdsrnpicdsyozqpovlpkckwakyBLIZZARDkzbwrhyegomacdchnnunoyaot",
                "ymlxqjqdnbsqoestoaahetFALLyxbmxvkytnsvpgvtixwhxmmqnarkuvtinhdizw",
                "uwshkkuqaipspjptznodicxtlwsnswruofqscGLACIERlmfpsywovgmdlfkbthtv",
                "aldwxxpqhpmzvgunbrpzbdpgzyFALLdiigcdqjmkqamrBEACHrcefsvmgxdgohwv",
                "ppxvdwldpyzgjzydxwrxxosbzjljalyvlzzetuouqqbmaxrgnhsxpicvoearadai",
                "wjyeofweohagfogpgqagxffnoqnzqunbujtdjtybkcftvolyopuadzljejkuvrfi",
                "hnascbcxogdvwxpuarnwibFROSTczvfhxqrhurtqkcfccfzmmyfzxakgcorskeps",
                "umnbyynkruaftdqaosflnvfuclcgpmyxetxkdslhjljwedffluivcxnzxobnbwdq",
                "ruasxsokjxaptzzivuzmiqfbgydduqjrtkuFALLivgkjljvgwfskqdcsccylriee",
                "dyzykaxzfbswnnbpdekyfspFALLjlnvoxwgFREEZEqsfqjlquzhxowpygmorgler",
                "FaxqxfahzfedCOLDrrztorrtrvzellotlcxgwgzlzxecqmjxndrcawdelowlgpje",
                "Amnmrqpjiqffcewrgpdmgnyfmxmuqzfzyunllmxndyilxfhgwijtdudkrcocdiih",
                "LmjwbwxtprbffsnbvetauseLEAVESasvfukfrycyoaimuryfzyvyujoyjxoywxca",
                "LosaqupoyooqdhmcrbhveesddicqzaumjkmzFALLkedgvykhckgxpluxmuqkmoeo",
                "owwpfjwvygvoludnuzsjupbjtbwdqgjycrxqvvsnjpigusmluwcemrptmwpdtlch",
                "vblvwjrafaTROPICALwdwduLEAVEStorejevvuwwukqaxtpemnaffmhidrtcryvl",
                "cwxtjarqnlrzzvvaqwffpypdjuoqnuvisgfduzeghbpjnhbxvvxdxofuitvfjhzw",
                "kwdlyijtxyyqsuhjgvyqgdayzhfqajxtshwyqjfkvrsrpgszmdztoeblywztkivt",
                "rrizfblspmcnfaydvdxksucbdjLEAVESzfktsjyuctqwwqqtheeaykjufknqatnz",
                "izohqhuradxjwerrpsbobmskejltvhiarpzmiozzxdxfwyfgxiwoomzfyzmaklvn",
                "nckolgxckkrsvpejjcuhfudwoasnrmscctflkibjprkkexhpnhrasexbepxednln",
                "sonxxojtddtolcmwsjldxmebqyuqgxlicbygTROPICALlncuznvdunwbidgcpeav",
                "fhvohuiamowfmwmavcynmdfikmqildknnwnckstyoknrhdhdjhmphimkmeoatpzn",
                "veoxamzrqheTROPICALbrxwofsnGLACIERbbqsaehuxlspulmjubewjhjzjfsgwo",
                "ntvxqonlvyvwkcpwuSUNSHINEjjawfqajffqgpbcdznndvdpsshqzdngdjltahjr",
                "rswhdsyosandqhztlgbtlrxmnzogqmzwmktcxxghuawmkugxdnsibvsuzvmbhtnm",
                "qhtxqmvsmICEdenqypjzsvjmfpwlxgukTROPICALnfervmdtgrpyauutacuwtolz",
                "vesfyhmkhcdptsocfcapzfvepfdbkvgenjggesfohijmceokthlyyxmfotmersun",
                "nkbdvdmwzddxiwvhtwlnywfklnznfmpmoihsqjcqubhyiikztgewjozvltsafmrl",
                "emwbsrjsvhjkiwdgowymjsjwigfdswntwnsbqeizvcwufojryldowqgiuvnbjajm",
                "odqritmmulcxlyzwnrtxhofcbpqoygtmjnsFLORALhetqlkaeocczlekppudseql",
                "vvqrzyakyfzrqfsqsmkwdnzaevwqkggorazyonkuzkyhsipknojvyelgkagasmct",
                "mjocyzsegklprgdmrozdhexexoumvcemkyqegfekusbltzgmwzjasehrjhuobdeb",
                "zmraydotgbtyeklylpqyyynqyrWINDhtbflacvkszyduzdtbvingerkzfplafgci"
            ];

            WordFinderBruteForce wordFinder = new(matrix);
            string[] wordstream =
            [
                "COLD", // * 1
                "CHILL", // * 1
                "WIND", // * 1
                "SNOW", // * 1
                "FROST", // * 1
                "ICE", // * 2
                "BLIZZARD", // * 2
                "FREEZE", // * 2
                // From here should be the returned values
                "GLACIER", // * 3 
                "FLORAL", // * 3 
                "SUNSHINE", // * 3
                "BEACH", // * 4
                "TROPICAL", // * 4 
                "HUMID", // * 4
                "HARVEST", // * 5
                "LEAVES", // * 5
                "FALL", // * 6
                "GOLDEN" // * 7
            ];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);

            // Assert
            Assert.NotEmpty(actual);
            Assert.Contains("GLACIER", actual);
            Assert.Contains("FLORAL", actual);
            Assert.Contains("SUNSHINE", actual);
            Assert.Contains("BEACH", actual);
            Assert.Contains("TROPICAL", actual);
            Assert.Contains("HUMID", actual);
            Assert.Contains("HARVEST", actual);
            Assert.Contains("LEAVES", actual);
            Assert.Contains("FALL", actual);
            Assert.Contains("GOLDEN", actual);
            Assert.DoesNotContain("COLD", actual);
            Assert.DoesNotContain("CHILL", actual);
            Assert.DoesNotContain("WIND", actual);
            Assert.DoesNotContain("SNOW", actual);
            Assert.DoesNotContain("FROST", actual);
            Assert.DoesNotContain("ICE", actual);
            Assert.DoesNotContain("BLIZZARD", actual);
            Assert.DoesNotContain("FREEZE", actual);
        }
    }
}
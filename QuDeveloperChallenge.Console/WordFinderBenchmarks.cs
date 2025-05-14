using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using QuDeveloperChallenge.Library;

namespace QuDeveloperChallenge.Console
{
    [MemoryDiagnoser]
    public class WordFinderBenchmarks
    {
        private readonly Consumer _consumer = new();
        private string[] _matrix = [];
        private string[] _wordstream = [];

        [GlobalSetup]
        public void GlobalSetup()
        {
            _matrix =
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
                "nlvbbnfgmbtwpsodkllozlmazbnyasahvnpgznddkguyzqhhoynuxtxlmvgnkdw",
                "dfwmdchmzeekawxrsviukznwgjbdbvrimfhmgaydkheacwxyzoqtbnvqsrmecju"
            ];
            _wordstream = [
                "banana", "apple", "orange", "grape", "lemon", "melon", "peach", "berry", "mango", "guava",
                "plum", "kiwi", "lime", "fig", "date", "pear", "apricot", "cherry", "papaya", "coconut",
            ];
        }

        [Benchmark(Baseline = true)]
        public void RunWordFinderBruteForceBenchmark()
        {
            WordFinderBruteForce wordFinder = new(_matrix);
            wordFinder.Find(_wordstream).Consume(_consumer);
        }
        
        [Benchmark]
        public void RunWordFinderRecursiveBenchmark()
        {
            WordFinderBruteForce wordFinder = new(_matrix);
            wordFinder.Find(_wordstream).Consume(_consumer);
        }
    }
}

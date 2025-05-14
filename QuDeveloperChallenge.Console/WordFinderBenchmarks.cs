// * Summary *

// BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
// AMD Ryzen 7 PRO 4750U with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
// .NET SDK 9.0.203
//
//| Method                               | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
//| RunWordFinderBruteForceBenchmark     | 208.49 us | 4.093 us | 8.722 us | 1.00  | 0.06    | 1.7090  | 3.76 KB   | 1.00        |
//| RunWordFinderRecursiveBenchmark      | 283.47 us | 5.630 us | 8.427 us | 1.36  | 0.07    | 1.4648  | 3.76 KB   | 1.00        |
//| RunWordFinderTransposingBenchmark    | 55.09 us  | 1.053 us | 0.879 us | 0.26  | 0.01    | 11.1084 | 22.78 KB  | 6.06        |

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
            WordFinderRecursive wordFinder = new(_matrix);
            wordFinder.Find(_wordstream).Consume(_consumer);
        }

        [Benchmark]
        public void RunWordFinderTransposingBenchmark()
        {
            WordFinderTransposing wordFinder = new(_matrix);
            wordFinder.Find(_wordstream).Consume(_consumer);
        }
    }
}

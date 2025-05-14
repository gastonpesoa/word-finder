using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuDeveloperChallenge.Library.Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Constructor_ShouldNotAssigNullToMatrixProp()
        {
            // Act
            WordFinder wordFinder = new(null);

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
            WordFinder wordFinder = new(matrix);

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
            WordFinder wordFinder = new(matrix);

            // Assert
            Assert.Empty(wordFinder.Matrix);
        }
        
        [Fact]
        public void Constructor_AllRowsShouldContainTheSameNumberOfCharacters()
        {
            // Arrange
            string[] matrix = ["jrx", "nhasdfsdf", "vivas", "qxfasdasdaiusfhiua"];

            // Act
            WordFinder wordFinder = new(matrix);

            // Assert
            Assert.Empty(wordFinder.Matrix);
        }

        [Fact]
        public void Find_ShoulReturnCollectionOfStrings()
        {
            // Arrange
            string[] matrix = [];
            WordFinder wordFinder = new(matrix);
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
            WordFinder wordFinder = new(matrix);
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
            WordFinder wordFinder = new(matrix);
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
            WordFinder wordFinder = new(matrix);
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
            WordFinder wordFinder = new(matrix);
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
            WordFinder wordFinder = new(matrix);
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
            string[] matrix = ["abcwec", "mwindx", "jcosac", "zoknro", "ilfehn", "edctyj",];
            WordFinder wordFinder = new(matrix);
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

            WordFinder wordFinder = new(matrix);
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
    }
}
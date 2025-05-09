namespace QuDeveloperChallenge.Library.Tests
{
    public class WordFinderTests
    {
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
                "nlvbbnfgmbtwpsodkllozlmazbnyasahvnpgznddkguyzqhhoynuxtxlmvgnkdw",
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
        }
    }
}
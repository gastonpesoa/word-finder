<a id="readme-top"></a>

[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/gastonpesoa/word-finder">
    <img src="./images/logo.png" alt="Logo" width="80" height="80">
  </a>
  <h3 align="center">Word Finder</h3>
  <p align="center">
    A .NET solution to search a large stream of words in a character matrix!
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#overview-of-the-challenge">Overview of the Challenge</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
      <a href="#design-decisions">Design Decisions</a>
      <ul>
        <li><a href="#implemented-algorithms">Implemented Algorithms</a></li>
      </ul>
    </li>
    <li>
      <a href="#benchmark-results">Benchmark Results</a>
      <ul>
        <li><a href="#test-environment">Test Environment</a></li>
        <li><a href="#performance-comparison">Performance Comparison</a></li>
        <li><a href="#insights">Insights</a></li>
        <li><a href="#final-decision">Final Decision</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>






## Overview of the Challenge

Presented with a character matrix and a large stream of words, your task is to create a Class that searches the matrix to look for the words from the word stream. Words may appear horizontally, from left to right, or vertically, from top to bottom. In the example below, the word stream has four words and the matrix contains only three of those words ("chill", "cold" and "wind"):

[![Product Name Screen Shot][product-screenshot]](https://example.com)

The search code must be implemented as a class with the following interface:

```cs
public class WordFinder
{
    public WordFinder(IEnumerable<string> matrix) 
    {
        ...
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    { 
        ...
    }
}
```

The WordFinder constructor receives a set of strings which represents a character matrix. The matrix size does not exceed 64x64, all strings contain the same number of characters. The "Find" method should return the top 10 most repeated words from the word stream found in the matrix. If no words are found, the "Find" method should return an empty set of strings. If any word in the word stream is found more than once within the stream, the search results should count it only once.



### Built With

* [![.NET 8.0][dotnet-shield]][dotnet-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>





## Getting Started

To get a local copy up and running follow these simple example steps.


### Prerequisites

[Visual Studio 2022](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the .NET desktop development workload installed. The .NET 8 SDK is automatically installed when you select this workload.

For more information, see [Install the .NET SDK with Visual Studio](https://learn.microsoft.com/en-us/dotnet/core/install/windows#install-with-visual-studio).





### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/gastonpesoa/word-finder.git
   ```
3. Start Visual Studio 2022.
  
4. Open the QuDeveloperChallenge.sln solution

5. Run the unit test

    From the menu bar, choose **Test > Run All Tests**. 

    *The Test Explorer window opens, and you should see that the WordFinderTests test passes*.

6. Run benchmarks
    ```sh
    dotnet run -c Release
    ```


<p align="right">(<a href="#readme-top">back to top</a>)</p>





## Design Decisions

To tackle the challenge of searching for words within a character matrix I decided to implement and evaluate three distinct algorithms. This approach allowed me to **benchmark their performance and allocated memory**, so I can choose the most efficient solution based on real metrics.




### Implemented Algorithms
1. **Brute-Force Search** (WordFinderBruteForce)

    A straightforward method that checks every possible starting point in the matrix and compares character-by-character in both horizontal and vertical directions.

2. **Recursive Search** (WordFinderRecursive)

    This approach compares characters in both horizontal and vertical directions recursively

3. **Transposed Matrix** (WordFinderTransposing)

    Converts columns into rows (i.e., transposes the matrix), so vertical searches can be performed as if they were horizontal.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- BENCHMARK RESULTS -->
## Benchmark Results 

To validate the efficiency of each algorithm, I used [BenchmarkDotNet](https://benchmarkdotnet.org/) to measure execution time and memory usage.

### Test Environment

* **OS**: Windows 10
* **CPU**: AMD Ryzen 7 PRO 4750U with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
* **.NET SDK**: 9.0.203
* **Tool**: BenchmarkDotNet v0.14.0

### Performance Comparison

| Method                              | Mean      | Error    | StdDev | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
| ----------------------------------- | --------- | -------- | ------ | ----- | ------- | ------- | --------- | ----------- |
| `RunWordFinderBruteForceBenchmark`  | 208.49 μs | ±8.72 μs |        | 1.00  | —       | 1.7090  | 3.76 KB   | 1.00        |
| `RunWordFinderRecursiveBenchmark`   | 283.47 μs | ±8.43 μs |        | 1.36  | ±0.07   | 1.4648  | 3.76 KB   | 1.00        |
| `RunWordFinderTransposingBenchmark` | 55.09 μs  | ±0.88 μs |        | 0.26  | ±0.01   | 11.1084 | 22.78 KB  | 6.06        |

### Insights

* The **Transpose-based algorithm** was **26.44% more efficient** compared to the Brute-Force baseline, delivering the best execution in this environment.
* Although it incurs a **memory increase (\~6.06x more than Brute-Force)** due to transposing and string handling, this tradeoff proved acceptable given the **significant boost in speed**.
* It also offered a **cleaner and more maintainable codebase**, avoiding deep recursion or character-by-character comparisons.

### Final Decision

The **Transpose-based approach** was selected as the **preferred implementation** due to its superior **performance** and **code maintainability**. It strikes the right balance between **speed, clarity, and scalability**, making it the best candidate for  scenarios involving large datasets.


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Gastón Pesoa - gastonpesoa@gmail.com - +54 9 11 2697-7960

Project Link: [https://github.com/gastonpesoa/word-finder](https://github.com/gastonpesoa/word-finder)

<p align="right">(<a href="#readme-top">back to top</a>)</p>




<!-- MARKDOWN LINKS & IMAGES -->

[forks-shield]: https://img.shields.io/github/forks/gastonpesoa/word-finder.svg?style=for-the-badge
[forks-url]: https://github.com/gastonpesoa/word-finder/network/members
[stars-shield]: https://img.shields.io/github/stars/gastonpesoa/word-finder.svg?style=for-the-badge
[stars-url]: https://github.com/gastonpesoa/word-finder/stargazers
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/gast%C3%B3n-pesoa-24a1b6164/

[product-screenshot]: images/screenshot.png
[dotnet-shield]: https://img.shields.io/badge/-.NET%208.0-blueviolet?logo=dotnet
[dotnet-url]: https://dotnet.microsoft.com/es-es/

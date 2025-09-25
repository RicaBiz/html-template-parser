# html-template-parser
<hr />
<h1>Easily generate new html pages and articles using templates!</h1>
<p>More details <a href="#details">below</a></p>

<h2>Easy GUI Program to create html pages and articles using templates</h2>
<p>This program uses template.html and article.txt files to create a new custom page with a specified title. All these can be done singurarly.
<br />
<ul>
  <li><b>Custom header.</b></li>
  <li><b>Custom footer.</b></li>
  <li><b>Custom article.</b></li>
  <li><b>Custom page template with custom title (with head and title tags).</b></li>
</ul></p>
<h3 id="details">How does it work</h3>
<p>Put all the files in the same folder as the program. Start the program. The GUI has only one page.
<br /><b>On the left</b> you can import the filenames, you will need to import the names of all necessary files for each operation. The filename is the name of the file to be generated, and is always required.
<br /><b>On the right</b> there are various messages displaying errors or updates. It will display whether you're missing necessary inputs or if it didn't find any file.
<br /><b>On the center</b> you can choose which options and which templates you want to create your page with.
<br /><b>Down</b> you can input the title that will go in the relative tag.
<br />The <b>Run Script</b> Button  will create a new file with your specified filename, according to the options you checked.</p>

<h3>GUI With <a href="https://github.com/raylib-cs/raylib-cs">Raylib-cs</a></h3>
<p>The GUI is made with the <a href="https://github.com/raylib-cs/raylib-cs">C# Raylib Bindings</a>.
<br />I made custom Buttons, TextBoxes and Checkboxes, so the code is quickly reusable and workflow is smooth.</p>

<h3>Written in C# .NET 8.0 uses Windows Forms to open Explorer</h3>
<p>Due to the use of Windows Forms the program is currently Windows Only, I will make a version without it soon.</p>


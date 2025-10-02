# html-template-parser RicaBiz
<hr />

# Easily generate new html pages and articles using templates!
<p>More details <a href="#details">below</a></p>

## Easy GUI Program to create html pages and articles using templates
<p>This program uses template.html and article.txt files to create a new custom page with a specified title or update existing html files. All these can be done singurarly.
<br />
<ul>
  <li><b>Add custom header to one or multiple files.</b></li>
  <li><b>Add custom footer to one or multiple files.</b></li>
  <li><b>Add custom article to one file.</b></li>
  <li><b>Create a custom page template with custom title.</b></li>
</ul></p>
<h3 id="details">How does it work</h3>
<p>Start the program. The GUI has only one page. Increase the size of the window if you can't see all GUI elements properly.
<br /><strong>ALL FILES MUST BE WELL FORMED XHTML. All attributes must have a value (i.e. required="") and all point tags must have the closing /.
<br /><b>On the left</b> you can import the filenames, you will need to import the names of all necessary files for each operation. The filename is the name of the file to be generated, and is always required.
<br /><b>On the right</b> there are various messages displaying errors or updates. It will display whether you're missing necessary inputs, if it didn't find any file or if files are missing necessary components.
<br /><b>On the center</b> you can choose which options and which templates you want to create your page with.
<br /><b>Down</b> you can input the title that will go in the relative tag.
<br />The <b>Run Script</b> Button will do the operations relative to the options you checked:
<ul>
  <li>Page Template: Create ONE new filename.html using the page-template.html file as basis, with a custom title.</li>
  <li>Header: Replaces the first header found in all the [filenames] specified with the first header in header.html.</li>
  <li>Footer: Replaces the first footer found in all the [filenames] specified with the first footer in footer.html.</li>
  <li>Article: Adds an article with structure h2 - p in the first article found in one filename.html. Replaces the h2 with the first line of the txt and adds the p made by all the other lines separated by a br tag</li>
</ul></p>

<h3>GUI With <a href="https://github.com/raylib-cs/raylib-cs">Raylib-cs</a></h3>
<p>The GUI is made with the <a href="https://github.com/raylib-cs/raylib-cs">C# Raylib Bindings</a>.
<br />I made custom Buttons, TextBoxes and Checkboxes, so the code is quickly reusable, workflow is smooth and debugging is easy.</p>

### Written in C# .NET 8.0 uses Windows Forms to open Explorer
<p>Due to the use of Windows Forms the program is currently Windows Only, I will make a version without it soon.</p>

### What is coming next
<p><ul>
  <li>Cross Platform version.</li>
  <li>Avoid crashing when xhtml is not well formed.</li>
  <li>Custom meta description.</li>
  <li>Custom css.</li>
  <li>Multiple articles handling.</li>
</ul></p>


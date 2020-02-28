using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace SplitMerge_CS
{
public class clFileSplitter
{

	private int BufferSize;
	private long MaxSplitSize = 524288000;
	private string splitFirstName = "PieceNum";
	private string splitReplaceToken = "REPLACEWITHTOKEN";
	private string splitExt = ".dat";
	private string targFileName = "";
	private string outputDir = "";
	private stats curStats;
	private bool delAfterSplit = false;

	private bool delAfterReasm = false;
	public struct stats
	{
		public int NumSplits;
		public long fSize;
		public System.DateTime startTime;

		public System.DateTime finishTime;
		public int timeTaken()
		{
			if (startTime == null || finishTime == null) {
				return -1;
			}
			return finishTime.Subtract(startTime).Seconds;
		}
	}

	public int maximumBufferSize {
		get { return BufferSize; }
		set { BufferSize = value; }
	}

	public bool deleteAfterSplit {
		get { return delAfterSplit; }
		set { delAfterSplit = value; }
	}

	public bool deleteAfterReassembly {
		get { return delAfterReasm; }
		set { delAfterReasm = value; }
	}

	public string outputPath {
		get { return outputDir; }
		set { outputDir = value; }
	}

	public string targetFile {
		get { return targFileName; }
		set { targFileName = value; }
	}

	public long MaxiumSplitSize {
		get { return MaxSplitSize; }
		set { MaxSplitSize = value; }
	}

	public string splitFileFirstName {
		get { return splitFirstName; }
		set { splitFirstName = value; }
	}

	public string splitFileReplaceToken {
		get { return splitReplaceToken; }
		set { splitReplaceToken = value; }
	}

	public string splitFileExtension {
		get { return splitExt; }
		set { splitExt = value; }
	}

	public stats getStats()
	{
		UpdateStats();
		return curStats;
	}
	/// <summary>

	public bool checkInputs(bool alertUser , bool isSplitOp)
	{
		//isSplitOp is used since we need more information to split rather than reassemble
		string Alerts = "";
        alertUser = false;
        isSplitOp = true;

		if (BufferSize <= 0) {
			BufferSize = 524288;
			//512kb
		}
		if (MaxSplitSize <= 0 && isSplitOp) {
			Alerts = Alerts + "Maxium split size is 0 or negative";
		}
		if (MaxSplitSize > 0 && MaxSplitSize < BufferSize) {
			//bad things happen when buffersize is larger than maxsplitsize
			//since we assume that we'll only need to create one new split file
			//to handle a buffer "block"
            double temp123 = MaxSplitSize / 2;
			BufferSize = Convert.ToInt32(Math.Floor(temp123));
		}
		if (string.IsNullOrEmpty(splitFirstName)) {
            Alerts = Alerts + "The first name to be appended to each split file is nothing";
		}
		if (string.IsNullOrEmpty(splitReplaceToken)) {
            Alerts = Alerts + "The token to replace with the split file count is nothing";
		}
		if (!System.IO.File.Exists(targFileName)) {
			Alerts = Alerts + "The target file name does not exist. " + targFileName;
		}
		if (!System.IO.Directory.Exists(outputDir)) {
			if (targFileName.LastIndexOf("\\") > -1) {
				outputDir = targFileName.Substring(0, targFileName.LastIndexOf("\\"));
			}
			if (outputDir.Length < 3) {
				Alerts = Alerts + "Invalid output directory.";
			}
		}
		if (!string.IsNullOrEmpty(Alerts)) {
			return false;
		}
		return true;
	}

	private void UpdateStats()
	{
		string baseName = "";
		string curSplitRep = null;
		string curSplitFileName = null;
		int curSplit = 0;
		long totalSize = 0;

		//If MaxSplitSize > 0 AndAlso System.IO.File.Exists(targFileName) Then
		if (System.IO.File.Exists(targFileName)) {
			baseName = targFileName.Substring(targFileName.LastIndexOf("\\") + 1, targFileName.Length - (targFileName.LastIndexOf("\\") + 1));
			if (baseName.IndexOf(splitFirstName) > -1) {
				baseName = baseName.Substring(0, baseName.LastIndexOf(splitFileFirstName));
				curSplitRep = targFileName.Substring(0, targFileName.LastIndexOf("\\")) + "\\" + baseName + splitFirstName + splitReplaceToken + splitExt;
				curSplitFileName = curSplitRep.Replace(splitReplaceToken, curSplit.ToString());
				while (System.IO.File.Exists(curSplitFileName)) {
					totalSize += Microsoft.VisualBasic.FileSystem.FileLen(curSplitFileName);
					curSplit += 1;
					curSplitFileName = curSplitRep.Replace(splitReplaceToken, curSplit.ToString());
				}
				curStats.NumSplits = curSplit;
				curStats.fSize = totalSize;
			} else if (MaxSplitSize > 0) {
                
				curStats.fSize = Microsoft.VisualBasic.FileSystem.FileLen(targFileName);
                double temp456 = curStats.fSize / MaxSplitSize;
				curStats.NumSplits = Convert.ToInt32(Math.Floor(temp456));
				if ((curStats.NumSplits * MaxSplitSize) - curStats.fSize < 0) {
					curStats.NumSplits += 1;
				}
			}
		}
	}

	public bool beginSplit()
	{
		System.IO.BinaryReader breader = null;
		System.IO.BinaryWriter bwriter = null;
		byte[] buffer = null;
		long fSize = 0;
		int curFileSplit = 0;
		long numLeftOverBytes = 0;
		long bytesRead = 0;
		long curSplitSize = 0;
		string curSplitFileName = "";
		string baseName = "";
		System.Security.AccessControl.FileSecurity targfileACL = default(System.Security.AccessControl.FileSecurity);
		//store file access control list, used on each split file

		if (!checkInputs(true, true)) {
			return false;
		}
		fSize = Microsoft.VisualBasic.FileSystem.FileLen(targFileName);
		if (fSize < MaxSplitSize) {
			
			return false;
		}
		targfileACL = new System.IO.FileInfo(targFileName).GetAccessControl();
		//bufferSize was checked so now we'll set it up
		buffer = new byte[BufferSize];
		UpdateStats();
		//make sure stats are setup and ready
		curStats.startTime = System.DateTime.Now;

		baseName = targFileName.Substring(targFileName.LastIndexOf("\\") + 1, targFileName.Length - (targFileName.LastIndexOf("\\") + 1));
		curSplitFileName = outputDir + "\\" + baseName + splitFirstName + splitReplaceToken + splitExt;

		try {
			//according to documentation opening the file this way may be faster due to the IO.FileOptions.SequentialScan flag
			//not sure if file.open class uses this flag anyway
			breader = new System.IO.BinaryReader(new System.IO.FileStream(targFileName, FileMode.Open, FileAccess.Read, FileShare.None, BufferSize, FileOptions.SequentialScan));
			//we'll setup the new file and give it the same ACLs as the target
			bwriter = new System.IO.BinaryWriter(System.IO.File.Create(curSplitFileName.Replace(splitReplaceToken, curFileSplit.ToString()), BufferSize, FileOptions.None, targfileACL));
			bytesRead = breader.Read(buffer, 0, BufferSize);
			while (bytesRead > 0) {
				if ((curSplitSize + bytesRead) > MaxSplitSize) {
					numLeftOverBytes = MaxSplitSize - curSplitSize;
					bwriter.Write(buffer, 0, Convert.ToInt32(numLeftOverBytes));
					bwriter.Flush();
					bwriter.Close();
					curFileSplit += 1;
					bwriter = new System.IO.BinaryWriter(System.IO.File.Create(curSplitFileName.Replace(splitReplaceToken, curFileSplit.ToString()), BufferSize, FileOptions.SequentialScan | FileOptions.WriteThrough, targfileACL));
					curSplitSize = bytesRead - numLeftOverBytes;
					if (onProgressStep != null) {
                        double temp789 = breader.BaseStream.Position / fSize;
                        double temp147 = curFileSplit / curStats.NumSplits;
						onProgressStep(Convert.ToInt32(Math.Floor((temp789) * 100)), Convert.ToInt32(Math.Floor((temp147) * 100)));
					}
					//RaiseEvent onProgressStep(Math.Floor((curSplitSize / MaxSplitSize) * 100), Math.Floor((curFileSplit / requiredSplits) * 100))
					if (!(numLeftOverBytes == 0)) {
						bwriter.Write(buffer, Convert.ToInt32(numLeftOverBytes - 1), Convert.ToInt32(curSplitSize));
					} else {
						//if CurSplitSize is = MaxSplitsize before the above if is evaluated
						//you'll end up with a full buffer here but leftOverBytes will be 0
						bwriter.Write(buffer, Convert.ToInt32(numLeftOverBytes), Convert.ToInt32(curSplitSize));
					}
				} else {
					bwriter.Write(buffer, 0, Convert.ToInt32(bytesRead));
					curSplitSize += bytesRead;
					if (onProgressStep != null) {
                        double temp258 = breader.BaseStream.Position / fSize;
                        double temp369 = curFileSplit / curStats.NumSplits;
						onProgressStep(Convert.ToInt32(Math.Floor((temp258) * 100)), Convert.ToInt32(Math.Floor((temp369) * 100)));
					}

				}
				bytesRead = breader.Read(buffer, 0, BufferSize);
			}
			curStats.finishTime = System.DateTime.Now;
		} catch (Exception ex) {
			
			//might want to do 
			return false;
		} finally {
			if ((breader != null)) {
				breader.Close();
			}
			if ((bwriter != null)) {
				bwriter.Flush();
				bwriter.Close();
			}
		}
		if (delAfterSplit) {
            Microsoft.VisualBasic.FileSystem.Kill(targFileName);
		}

		return true;
	}

    public bool beginReassembly()
    {
        System.IO.BinaryReader breader = null;
		System.IO.BinaryWriter bwriter = null;
		byte[] buffer = null;
		int curFileSplit = 0;
		long bytesRead = 0;
		string curSplitFileName = "";
		string baseName = "";
		System.Security.AccessControl.FileSecurity targfileACL = null;
		//store file access control list, used on each split file
		long fSize = 0;


		try
        {
            if (!checkInputs(true, false))
            {
                return false;
            }

            targfileACL = new System.IO.FileInfo(targFileName).GetAccessControl();
            //bufferSize was checked so now we'll set it up
            buffer = new byte[BufferSize];
            UpdateStats();
            //make sure stats are setup and ready
            curStats.startTime = System.DateTime.Now;

            baseName = targFileName.Substring(targFileName.LastIndexOf("\\") + 1, targFileName.Length - (targFileName.LastIndexOf("\\") + 1));
            baseName = baseName.Substring(0, baseName.LastIndexOf(splitFileFirstName));

            curSplitFileName = outputDir + "\\" + baseName + splitFirstName + splitReplaceToken + splitExt;

			//we'll setup the new file and give it the same ACLs as the target
			bwriter = new System.IO.BinaryWriter(System.IO.File.Create(outputDir + "\\" + baseName, BufferSize, System.IO.FileOptions.None, targfileACL));

			while (System.IO.File.Exists(curSplitFileName.Replace(splitReplaceToken, curFileSplit.ToString()))) {
				breader = new System.IO.BinaryReader(new System.IO.FileStream(curSplitFileName.Replace(splitReplaceToken, curFileSplit.ToString()), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None, BufferSize, System.IO.FileOptions.SequentialScan));
				bytesRead = breader.Read(buffer, 0, BufferSize);
                fSize = Microsoft.VisualBasic.FileSystem.FileLen(curSplitFileName.Replace(splitFileReplaceToken, curFileSplit.ToString()));

				while (bytesRead > 0) {
					bwriter.Write(buffer, 0, Convert.ToInt32(bytesRead));
					if (onProgressStep != null) {
                        double temp14 = (breader.BaseStream.Position / fSize) * 100;
                        double temp15 = (curFileSplit / curStats.NumSplits) * 100;
						onProgressStep(Convert.ToInt32(Math.Floor(temp14)), Convert.ToInt32(Math.Floor(temp15)));
					}
					bytesRead = breader.Read(buffer, 0, BufferSize);
				}
				breader.Close();
				breader = null;
				//avoid exception in finally block
				if (delAfterReasm) {
                    Microsoft.VisualBasic.FileSystem.Kill(curSplitFileName.Replace(splitReplaceToken, curFileSplit.ToString()));
					
				}
				curFileSplit += 1;
			}
			curStats.finishTime = System.DateTime.Now;
			//frmMain.ToolStripProgressBar1.Value = 0;
			//frmMain.tlStrpMainProgressBar.Value = 0;
		} 
        catch (Exception ex)
        {
			return false;
		}
        finally 
        {
			if ((breader != null)) {
				breader.Close();
			}
			if ((bwriter != null)) {
				bwriter.Flush();
				bwriter.Close();
			}
		}


		return true;
    }

	public event onProgressStepEventHandler onProgressStep;
	public delegate void onProgressStepEventHandler(int curFileProg, int totalProgress);
	public event operationCompleteEventHandler operationComplete;
	public delegate void operationCompleteEventHandler();

}


}
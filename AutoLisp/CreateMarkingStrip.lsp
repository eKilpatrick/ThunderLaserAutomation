(vl-load-com)

;MUST turn OFF osnap in Autocad.
;Type in OSNAP in the command line, then uncheck the top checkbox.

(defun CreateMarkingStrip ()
  ;(print "Starting Create Marking Strip")
  
  (CreateLayers)

  (CreateBox)

  (ReadFile)
  
  (LoopList)

  (MergeLines)

  (command "zoom" "e")
  
  (SendComplete)
  (print "Finished Create Marking Strip")

  (SaveAsDXF)
  ;(command "._CLOSE")
  ;(command "._CLOSE")
)

;EMK 9/2022
;Purpose: Loops through a text file with dimensions of marking strips and text to create a file to engrave
(defun LoopList ()

  (foreach item plt

	(print "Before text")
    (setq text (nth 0 (sparser item ",")))
	(print text)
    (setq CoordX (atof (nth 1 (sparser item ","))))
	(print CoordX)
	(setq CoordX (+ CoordX 1.5)) ;Problems engraving on first 1.5" section of workspace, so shift everything over by 1.5" to the right
    (setq CoordY (atof (nth 2 (sparser item ","))))
	(print CoordY)
	(setq CoordY (- 20 CoordY))
    (setq rotate (nth 3 (sparser item ",")))
	(print rotate)
    (setq width (atof (nth 4 (sparser item ","))))
	(print width)
    (setq height (atof (nth 5 (sparser item ","))))
	(print height)
    (setq holeDiam (atof (nth 6 (sparser item ","))))
	(print holeDiam)
    (setq holeRad (/ holeDiam 2))
    (setq holeDistX (atof (nth 7 (sparser item ","))))
	(print holeDistX)
    (setq holeDistY (atof (nth 8 (sparser item ","))))
	(print holeDistY)
    (setq MultiText (atoi (nth 9 (sparser item ","))))
	(print MultiText)
    (setq TextLoc (nth 10 (sparser item ",")))
	(print TextLoc)
    (setq TextHeight (nth 11 (sparser item ",")))
	(print TextHeight)

    (setvar "clayer" "Text")

    ;Checks to see if the marking strip has more than one line of text on it
    (if (= MultiText 0)
      (progn
        ;Has only one line
        (if (= rotate "True")
          (progn
            (command "._MTEXT" (list (+ CoordX (/ height 2)) (- CoordY (/ width 2)) 0) "Justify" "MC" "Height" TextHeight "Rotation" 90.0 (list  (+ CoordX (/ height 2)) (- CoordY (/ width 2)) 0) text "")
          )
          (progn
            (command "._MTEXT" (list (+ CoordX (/ width 2)) (- CoordY (/ height 2)) 0) "Justify" "MC" "Height" TextHeight (list (+ CoordX (/ width 2)) (- CoordY (/ height 2)) 0) text "")
          )
        )
      )
      (progn
        ;Has multiple lines
        (setq n 0)
        (setq m 0)
        (while (< n MultiText)
          (setq CurrentStr (nth n (sparser text ";")))
          (setq CurrentTextHeight (atof (nth n (sparser TextHeight ";"))))
          (setq TextX (atof (nth m (sparser TextLoc ";"))))
          (setq m (+ m 1))
          (setq TextY (atof (nth m (sparser TextLoc ";"))))

          (if (= rotate "True")
            (progn
              (command "._MTEXT" (list (+ CoordX TextY) (- CoordY TextX) 0) "Justify" "MC" "Height" CurrentTextHeight "Rotation" 90.0 (list (+ CoordX TextY) (- CoordY TextX) 0) CurrentStr "")
            )
            (progn
              (command "._MTEXT" (list (+ CoordX TextX) (- CoordY TextY) 0) "Justify" "MC" "Height" CurrentTextHeight (list (+ CoordX TextX) (- CoordY TextY) 0) CurrentStr "")
            )
          )

          (setq n (+ n 1))
          (setq m (+ m 1))
        )
      )
    )

    (setvar "clayer" "Lines")
    (setq pt1 (list CoordX CoordY 0.0))
    (if (= rotate "True")
      (progn
        (setq pt2 (polar pt1 0 height))
        (setq pt3 (polar pt2 (/ pi 2) (- 0 width)))
        (setq pt4 (polar pt3 pi height))
      )
      (progn
        (setq pt2 (polar pt1 0 width))
        (setq pt3 (polar pt2 (/ pi 2) (- 0 height)))
        (setq pt4 (polar pt3 pi width))
      )
    )
    (command "line" pt1 pt2 pt3 pt4 pt1 "")

	(setvar "clayer" "Holes")
    (if (= holeDiam 0)
      (progn
        ;This means there is no hole for this part
      )
      (progn  
        (if (= rotate "True")
          (progn
            (setq Hole1X (+ CoordX holeDistY))
            (setq Hole2X (- (+ CoordX height) holeDistY))
            (setq Hole1Y (- CoordY holeDistX))
            (setq Hole2Y (+ (- CoordY width) holeDistX))
          )
          (progn
            (setq Hole1X (+ CoordX holeDistX))
            (setq Hole2X (- (+ CoordX width) holeDistX))
            (setq Hole1Y (- CoordY holeDistY))
            (setq Hole2Y (+ (- CoordY height) holeDistY))
          )
        )
        
        (command "._CIRCLE" (list Hole1X Hole1Y) holeRad "")
        (command "._CIRCLE" (list Hole2X Hole2Y) holeRad "")
      )
    )
  )
)

(defun ReadFile ()
  (setq textRead (open "\\\\ad101.siemens-energy.net\\dfs101\\File_SE\\NAM\\RCH_Public\\Co-ops\\ThunderLaser\\RUNNING_CODE\\MarkingStripInfo.txt" "r"))
  (setq count 0)
  
  (while (setq fil (read-line textRead))
    (if (not (null fil))
      (progn
        (setq plt (append plt (list fil)))
        (setq count (1+ count))
      )
    )
  )
  (close textRead)
)

(defun CreateBox ()
  (setvar "clayer" "T2")
  (setq pt1 (list 0 0 0))
  (setq pt2 (polar pt1 0 32))
  (setq pt3 (polar pt2 (/ pi 2) 20))
  (setq pt4 (polar pt3 pi 32))
  (command "line" pt1 pt2 pt3 pt4 pt1 "")
)

;EMK 9/2022
;Purpose: To allow multiple layers to insert elements during the lisp so when imported to LightBurn, the different elements can be on different layers in LightBurn
(defun CreateLayers ()
  ;Create the layer where the lines go and make it black
  (command "-layer" "New" "Lines" "")
  (command "-layer" "Color" "Truecolor" "0,0,0" "Lines" "")
  
  ;Create the layer where the holes go and make it redraw
  (command "-layer" "New" "Holes" "")
  (command "-layer" "Color" "Truecolor" "255, 0, 0" "Holes" "")

  ;Create the layer where the text goes and make it blue
  (command "-layer" "New" "Text" "")
  (command "-layer" "Color" "Truecolor" "0,0,255" "Text" "")

  ;Create the layer where the Bounding box goes and put it in the virtual layer that doesn't go to the laser
  (command "-layer" "New" "T2" "")
  (command "-layer" "Color" "Truecolor" "12, 144, 209" "T2" "")
)

(defun MergeLines ()
  (setq sel1 (ssget "_X" (list (cons 8 "Lines"))))
  (sssetfirst nil sel1)
  (joinlines)
)
;EMK 10/2021
;Purpose: Allows vb.net program to know if lisp file has completed...
(defun SendComplete ()

	(setq fn (open (findfile "C:\\Program Files\\Autodesk\\AutoCAD 2023\\Support\\ScriptComplete.txt") "w"))
	(write-line "1" fn)
	(close fn)
)

(defun SaveAsDXF ()
  (vl-mkdir "\\\\ad101.siemens-energy.net\\dfs101\\File_SE\\NAM\\RCH_Public\\Co-ops\\ThunderLaser\\RUNNING_CODE\\")
  (setq SaveAsPath (strcat "\\\\ad101.siemens-energy.net\\dfs101\\File_SE\\NAM\\RCH_Public\\Co-ops\\ThunderLaser\\RUNNING_CODE\\CurrentFile.dxf"))
  (overwrite SaveAsPath)
  (vla-saveas (vla-get-ActiveDocument (vlax-get-Acad-Object)) SaveAsPath acr15_DXF)
)

(defun overwrite ( overwritePath )

    (if (findfile overwritePath) (vl-file-delete overwritePath))
);defun

;accepts: str - string to be split
;         delim - character to split the string at
(defun sparser (str delim / ptr lst)
    (while (setq ptr (vl-string-search delim str))
	(setq lst (cons (substr str 1 ptr) lst))
	(setq str (substr str (+ ptr 2)))
    )
    (reverse (cons str lst))
);defun


;Found online on autodesk forum written by Lee Mac
;; Join Lines  -  Lee Mac
;; Joins collinear lines in a selection, retaining all original properties.

(defun joinlines ( / process e i l s x )

    (defun process ( l / x r )
        (if (setq x (car l))
            (progn
                (foreach y (cdr l)
                    (if (vl-every '(lambda ( a ) (apply 'LM:collinear-p (cons a (cdr x)))) (cdr y))
                        (setq x (cons (car x) (LM:furthestapart (append (cdr x) (cdr y)))))
                        (setq r (cons y r))
                    )
                )
                (entmake (append (car x) (mapcar 'cons '(10 11) (cdr x))))
                (process r)
            )
        )
    )
    (if (setq s (ssget "_:L" '((0 . "LINE"))))
        (process
            (repeat (setq i (sslength s))
                (setq e (ssname s (setq i (1- i)))
                      x (entget e)
                      e (entdel e)
                      l (cons (list x (cdr (assoc 10 x)) (cdr (assoc 11 x))) l)
                )
            )
        )
    )
    (princ)
)

;; Furthest Apart  -  Lee Mac
;; Returns the two points furthest apart in a given list

(defun LM:furthestapart ( lst / di1 di2 pt1 rtn )
    (setq di1 0.0)
    (while (setq pt1 (car lst))
        (foreach pt2 (setq lst (cdr lst))
            (if (< di1 (setq di2 (distance pt1 pt2)))
                (setq di1 di2
                      rtn (list pt1 pt2)
                )
            )
        )
    )
    rtn
)

;; Collinear-p  -  Lee Mac
;; Returns T if p1,p2,p3 are collinear

(defun LM:Collinear-p ( p1 p2 p3 )
    (
        (lambda ( a b c )
            (or
                (equal (+ a b) c 1e-8)
                (equal (+ b c) a 1e-8)
                (equal (+ c a) b 1e-8)
            )
        )
        (distance p1 p2) (distance p2 p3) (distance p1 p3)
    )
)
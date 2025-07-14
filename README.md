# Tool for Bulk Renaming Images Based on Their Dominant Color

How to use:
- Select a directory containing your images.
- Add sprite colors to the table (enter HEX values manually or use the color palette).
- Click "Start".

The script will:
- Scan all subdirectories.
- Detect the dominant color of each sprite.
- Match it to the closest color in your palette (using approximate color matching, not exact HEX comparisons).
- Rename all sprites in the format:
- bg_{color}_{type}, where {type} is the name of the sprite’s original directory.

<img width="616" height="502" alt="image" src="https://github.com/user-attachments/assets/1f748f21-ceb6-4539-87e1-024abbe3057a" />

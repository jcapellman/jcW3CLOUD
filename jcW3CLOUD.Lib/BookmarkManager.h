#ifndef __BOOKMARKMANAGER__
#define __BOOKMARKMANAGER__

#include "Main.h"
#include "BookmarkItem.h"
#include "FileReader.h"
#include "FileWriter.h"

class BookmarkManager {
	public:
		BookmarkManager(string fileName);
		BookmarkManager();
		~BookmarkManager();

		bool AddBookmark(string description, string url);
		bool RemoveBook(int id);

		vector<BookmarkItem> GetAll();

		bool WriteBookmarksToFile();
	private:
		int generateID();

		vector<BookmarkItem> _bookmarks;
};

#endif

//
//  CellsTableViewCell.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/8/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

protocol PlayerCellDelegate {
    func didSetPlayer(player: Player, cell: PlayerViewCell)
}

class PlayerViewCell: UITableViewCell {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
    var delegate: PlayerCellDelegate?
    
    ////////////////////////////////////
    //Global Variables
    ////////////////////////////////////
    var player: Player? {
        didSet {
            if let player = player {
                delegate?.didSetPlayer(player: player, cell: self)
            }
            
            if let bg = player?.backgroundImage {
                backgroundImage.image = bg
            }
            
            if let pimage = player?.profileImage {
                profileImage.image = pimage
            }
            
            if let summonerName = player?.summonerName {
                summonerNameLabel.text = summonerName
            }
            
            if let summonerChampion = player?.championName {
                summonerChampionLabel.text = summonerChampion
            }
            
            if let spell1 = player?.spell1 {
                spell1ImageView.image = spell1
            }
            
            if let spell2 = player?.spell2 {
                spell2ImageView.image = spell2
            }
            
        }
    }
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let backgroundImage: UIImageView = {
        let imageView = UIImageView()
//        imageView.image = UIImage(named: "tempChampion")
        imageView.clipsToBounds = true
        imageView.contentMode = UIViewContentMode.scaleAspectFill
        return imageView
    }()
    
    let profileImage: UIImageView = {
        let imageView = UIImageView()

        if (UIDevice.current.userInterfaceIdiom == UIUserInterfaceIdiom.pad) {
            imageView.frame.size = CGSize(width: Helper.getWidthOf(xdWidth: 35, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width), height: Helper.getWidthOf(xdWidth: 35, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width))
        } else {
            imageView.frame.size = CGSize(width: 45, height: 45)
        }
//        imageView.image = UIImage(named: "tempProfile")
        imageView.clipsToBounds = true
        imageView.contentMode = UIViewContentMode.scaleAspectFill
        imageView.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
        imageView.layer.borderColor = UIColor(hex: "#95989A")?.cgColor
        
        imageView.layer.cornerRadius = imageView.frame.height / 2
        return imageView
    }()
    
    let summonerInfoView: UIView = {
        let view = UIView()
//        view.backgroundColor = UIColor.red
        return view
    }()
    
    let summonerNameLabel: UILabel = {
        let label = UILabel()
        label.textColor = UIColor(hex: "#95989A")
        label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        label.numberOfLines = 0
        label.textAlignment = .left
        return label
    }()
    
    let summonerChampionLabel: UILabel = {
        let label = UILabel()
        label.textColor = UIColor(hex: "#95989A")
        label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 12, referenceHeight: nil, referenceWidth: nil))
        label.numberOfLines = 0
        label.textAlignment = .left
        return label
    }()
    
    let spell1ImageView: UIImageView = {
        let view =  UIImageView()
        
        if (UIDevice.current.userInterfaceIdiom == UIUserInterfaceIdiom.pad) {
            view.frame.size = CGSize(width: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width), height: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width))
        } else {
            view.frame.size = CGSize(width: 24, height: 24)
        }
        //        imageView.image = UIImage(named: "tempProfile")
        view.clipsToBounds = true
        view.contentMode = UIViewContentMode.scaleAspectFill
        view.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
        view.layer.borderColor = UIColor(hex: "#95989A")?.cgColor
        
        return view
    }()
    
    let spell2ImageView: UIImageView = {
        let view =  UIImageView()
        
        if (UIDevice.current.userInterfaceIdiom == UIUserInterfaceIdiom.pad) {
            view.frame.size = CGSize(width: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width), height: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width))
        } else {
            view.frame.size = CGSize(width: 24, height: 24)
        }
        //        imageView.image = UIImage(named: "tempProfile")
        view.clipsToBounds = true
        view.contentMode = UIViewContentMode.scaleAspectFill
        view.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
        view.layer.borderColor = UIColor(hex: "#95989A")?.cgColor
        
        return view
    }()
    
    ////////// END OF CONTROLS /////////
    
    override init(style: UITableViewCellStyle, reuseIdentifier: String?) {
        super.init(style: style, reuseIdentifier: reuseIdentifier)
        setupCell()
        addSubViews()
        setupConstraints()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }
    
    func setupCell() {
        backgroundColor = .clear
        
        selectedBackgroundView = {
            let v = UIView()
            v.backgroundColor = .clear
            return v
        }()
        
        addSubViews()
        setupConstraints()
    }
    
    func addSubViews() {
        addSubview(backgroundImage)
        addSubview(profileImage)
        addSubview(summonerInfoView)
        summonerInfoView.addSubview(summonerNameLabel)
        summonerInfoView.addSubview(summonerChampionLabel)
        addSubview(spell1ImageView)
        addSubview(spell2ImageView)
    }
    
    func setupConstraints() {
        // DISABLE FRAMES
        backgroundImage.translatesAutoresizingMaskIntoConstraints = false
        profileImage.translatesAutoresizingMaskIntoConstraints = false
        summonerInfoView.translatesAutoresizingMaskIntoConstraints = false
        summonerNameLabel.translatesAutoresizingMaskIntoConstraints = false
        summonerChampionLabel.translatesAutoresizingMaskIntoConstraints = false
        spell1ImageView.translatesAutoresizingMaskIntoConstraints = false
        spell2ImageView.translatesAutoresizingMaskIntoConstraints = false
        
        // BACKGROUND IMAGE
        addConstraintsWithFormat(format: "H:|[v0]|", views: backgroundImage)
        addConstraintsWithFormat(format: "V:|[v0]|", views: backgroundImage)
        
        // PROFILE IMAGE
        profileImage.leftAnchor.constraint(equalTo: leftAnchor, constant: Helper.getWidthOf(xdWidth: 14, referenceWidth: nil, originalWidth: nil)).isActive = true
        profileImage.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
        if (UIDevice.current.userInterfaceIdiom == UIUserInterfaceIdiom.pad) {
            profileImage.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 35, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width)).isActive = true
            profileImage.heightAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 35, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width)).isActive = true
        } else {
            profileImage.widthAnchor.constraint(equalToConstant: 45).isActive = true
            profileImage.heightAnchor.constraint(equalToConstant: 45).isActive = true
        }
        
        // SUMMONER INFO
//        summonerInfoView.widthAnchor.constraint(equalToConstant: 113).isActive = true
        summonerInfoView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 27, referenceHeight: nil, originalHeight: nil)).isActive = true
        summonerInfoView.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
        summonerInfoView.leftAnchor.constraint(equalTo: profileImage.rightAnchor, constant: 9).isActive = true
        summonerNameLabel.leftAnchor.constraint(equalTo: summonerInfoView.leftAnchor).isActive = true
        summonerChampionLabel.leftAnchor.constraint(equalTo: summonerInfoView.leftAnchor).isActive = true
        
        summonerNameLabel.topAnchor.constraint(equalTo: summonerInfoView.topAnchor).isActive = true
        summonerChampionLabel.bottomAnchor.constraint(equalTo: summonerInfoView.bottomAnchor, constant: 0).isActive = true
  
        spell2ImageView.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
//        spell2ImageView.topAnchor.constraint(equalTo: summonerNameLabel.topAnchor).isActive = true
        spell2ImageView.rightAnchor.constraint(equalTo: rightAnchor, constant: -Helper.getWidthOf(xdWidth: 14, referenceWidth: nil, originalWidth: nil)).isActive = true
        spell2ImageView.heightAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width)).isActive = true
        spell2ImageView.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width)).isActive = true
        
//        spell1ImageView.topAnchor.constraint(equalTo: summonerNameLabel.topAnchor).isActive = true
        spell1ImageView.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
        spell1ImageView.rightAnchor.constraint(equalTo: spell2ImageView.leftAnchor, constant: -7).isActive = true
        spell1ImageView.heightAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width)).isActive = true
        spell1ImageView.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 24, referenceWidth: 375, originalWidth: UIScreen.main.bounds.width)).isActive = true
        
    }

}
